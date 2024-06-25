using SHM.Domain.Dto.Sahc0106;
using SHM.Domain.Enums;
using SHM.Domain.Models.Sahc0106;
using System.Globalization;



namespace SHM.Domain.Helper;



/// <summary>
/// Clase que contiene la logica de negocio para el motor de pagos
/// </summary>
public static class PaymentEngineCore
{



    /// <summary>
    /// Metodo que se encarga de actualizar los saldos de los pagos en las tarjetas de credito
    /// </summary>
    /// <param name="motorDto"></param>
    /// <returns></returns>
    public static async Task<PayMotorDTO> UpdateBalance(PayMotorDTO motorDto)
    {

        try
        {

            CreditCardMasterTransactionDTO newTransactionDTO = motorDto.TranDto;

            
            PayMotorDTO PayMotorUpdated = null;

            var option = motorDto.transactionsType.AdjusmentType.ToUpper().Trim();

            switch (option)
            {
                case "CREDIT":
                    PayMotorUpdated = await ApplyCredit(motorDto);
                    break;

                case "DEBIT":
                    PayMotorUpdated = await ApplyDebit(motorDto);
                    break;
            }



            return PayMotorUpdated;

        }
        catch (Exception e)
        {
            await ElasticAlert.LogErrorToElastic(e, "GetBalance");
            motorDto.ErrorMessage = "Error al seleccionar el tipo de transacción. Reportar a equipo de soporte.";
            return motorDto;
        }
    }



    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static async Task<PayMotorDTO> CreateProcessoDetail(PayMotorDTO motorDto)
    {

        try
        {
            
            //Creamos el log
            motorDto.tranProcessorLog = new CreditCardTransactionProcessorLog();
            motorDto.tranProcessorLog.CreditCardTransactionProcessorKey = motorDto.tranProcessor.CreditCardTransactionProcessorKey;
            motorDto.tranProcessorLog.LastPayDate = motorDto.tranProcessor.LastPayDate;
            motorDto.tranProcessorLog.LastPayNumber = motorDto.tranProcessor.LastPayNumber;
            motorDto.tranProcessorLog.LastBillDate = motorDto.tranProcessor.LastBillDate;
            motorDto.tranProcessorLog.LastBillNumber = motorDto.tranProcessor.LastBillNumber;
            motorDto.tranProcessorLog.CreditLimit = motorDto.tranProcessor.CreditLimit;
            motorDto.tranProcessorLog.Available = motorDto.tranProcessor.Available;
            motorDto.tranProcessorLog.Balance = motorDto.tranProcessor.Balance;
            motorDto.tranProcessorLog.MinimunPayment = motorDto.tranProcessor.MinimunPayment;
            motorDto.tranProcessorLog.ApprovalNumber = motorDto.numOperationStr;
            motorDto.tranProcessorLog.Created = TimeZoneHelperTest.GetPanamaTime();

            //Log de compras
            motorDto.tranProcessorLog.Balance30 = motorDto.tranProcessor.Balance30;
            motorDto.tranProcessorLog.Balance60 = motorDto.tranProcessor.Balance60;
            motorDto.tranProcessorLog.Balance90 = motorDto.tranProcessor.Balance90;
            motorDto.tranProcessorLog.Balance120 = motorDto.tranProcessor.Balance120;

            //Log de cargos
            motorDto.tranProcessorLog.Cargo = motorDto.tranProcessor.Cargo;
            motorDto.tranProcessorLog.Cargo30 = motorDto.tranProcessor.Cargo30;
            motorDto.tranProcessorLog.Cargo60 = motorDto.tranProcessor.Cargo60;
            motorDto.tranProcessorLog.Cargo90 = motorDto.tranProcessor.Cargo90;
            motorDto.tranProcessorLog.Cargo120 = motorDto.tranProcessor.Cargo120;


            //TransactionType transactionType = EnumExtensions.ParseEnum<TransactionType>(motorDto.transactionsType.ExternalCode1);


            //Creamos la transaccion
            motorDto.tranProcessorDetail = new CreditCardTransactionProcessorDetail();
            motorDto.tranProcessorDetail.CreditCardTransactionProcessorKey = motorDto.tranProcessor.CreditCardTransactionProcessorKey;
            motorDto.tranProcessorDetail.TypeMovement = motorDto.transactionsType.ExternalCode1;
            motorDto.tranProcessorDetail.Value = motorDto.TranDto.Amount;
            motorDto.tranProcessorDetail.Balance = motorDto.tranProcessor.Balance;
            motorDto.tranProcessorDetail.StoreId = motorDto.branchMasterGeneral.Code;
            motorDto.tranProcessorDetail.PostId = motorDto.TranDto.PosId;
            motorDto.tranProcessorDetail.UserId = motorDto.TranDto.User;
            motorDto.tranProcessorDetail.CardNumber = motorDto.TranDto.CardNumber;
            motorDto.tranProcessorDetail.CodClient = motorDto.TranDto.CodCliente;
            motorDto.tranProcessorDetail.Message = $"{motorDto.transactionsType.Description} en {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(motorDto.branchMasterGeneral.Detail)}";
            motorDto.tranProcessorDetail.TransactionNumber = motorDto.TranDto.TransactionNumber;
            motorDto.tranProcessorDetail.ApprovalNumber = motorDto.numOperationStr;
            motorDto.tranProcessorDetail.DateField = motorDto.TranDto.DateTime.Value;
            motorDto.tranProcessorDetail.TimeField = motorDto.TranDto.DateTime.Value.TimeOfDay;
            motorDto.tranProcessorDetail.CreditCardTransactionTypeKey = motorDto.TranDto.TransactionTypeKey;

            motorDto.tranProcessorDetail.ExecutingSystem = motorDto.TranDto.ExecutingSystem;
            motorDto.tranProcessorDetail.ExecutingSystemTransactionId = motorDto.TranDto.ExecutingSystemTransactionId;
            motorDto.tranProcessorDetail.ExecutingSystemTransactionKey = motorDto.TranDto.ExecutingSystemTransactionKey;
            motorDto.tranProcessorDetail.Created = TimeZoneHelperTest.GetPanamaTime();

            if (motorDto.CycleMaster != null)
            {
                //Actualizamos la transaccion.
                motorDto.CycleMaster.NumOperation = motorDto.numOperationStr;
                motorDto.CycleMaster.Modified = TimeZoneHelperTest.GetPanamaTime();
            }
           



            return motorDto;
        }
        catch (Exception e)
        {
            await ElasticAlert.LogErrorToElastic(e, "CreateProcessoDetail");
            motorDto.ErrorMessage = "Error al crear transacción. Reportar a equipo de soporte.";
            return motorDto;

        }

    }



    /// <summary>
    /// Metodo para aplicar Debito.
    /// </summary>
    /// <param name="motorDto"></param>
    /// <returns></returns>
    public static async Task<PayMotorDTO> ApplyDebit(PayMotorDTO motorDto)
    {

        try
        {

            //No se puede realizar una compra si no hay saldo disponible.
            if (motorDto.tranProcessor.Available < motorDto.TranDto.Amount  && motorDto.transactionsType.CreditCardTransactionsTypeKey == motorDto.TransactionBuy.CreditCardTransactionsTypeKey)
            {
                var PaymentAmount = Math.Round(motorDto.TranDto.Amount - motorDto.tranProcessor.Available, 2);
                var PaymentAmountFormat = PaymentAmount.ToString("N2", new CultureInfo("en-US"));

                motorDto.ErrorMessage = $"No hay saldo suficiente para realizar la transacción. Debe abonar un monto de ${PaymentAmountFormat} para poder transaccionar.";
                return motorDto;
            }


            //if (motorDto.tranProcessor.Available < motorDto.tranDto.Amount && motorDto.transactionsType.ExternalCode1.Trim() == "02")
            //{
            //    var PaymentAmount = Math.Round(motorDto.tranDto.Amount - motorDto.tranProcessor.Available, 2);
            //    var PaymentAmountFormat = PaymentAmount.ToString("N2", new CultureInfo("en-US"));

            //    motorDto.ErrorMessage = $"No hay saldo suficiente para realizar la compra. Debe abonar un monto de ${PaymentAmountFormat} para poder transaccionar.";
            //    return motorDto;
            //}


            //Se controlara por transactionType
            ////No se puede realizar una compra si el estado de la tarjeta es diferente a Activa.
            //if (motorDto.creditCardList.Status.ToString() != ((int)StatusCard.Activa).ToString() && motorDto.transactionsType.ExternalCode1.Trim() == "02")
            //{
            //    StatusCard statusCard = (StatusCard)Enum.Parse(typeof(StatusCard), motorDto.creditCardList.Status.ToString());
            //    string statusString = statusCard.ToString();

            //    motorDto.ErrorMessage = $"La tarjeta con el numero: {motorDto.creditCardList.CardNumber} se encuentra en estado '{statusString}'. Por favor, comuníquese con un ejecutivo de cuenta para verificar su estado.";
            //    return motorDto;
            //}






            decimal buyToApply = motorDto.TranDto.Amount;


            motorDto.tranProcessor.Current += buyToApply;

            //Reducimos el disponible.
            motorDto.tranProcessor.Available = motorDto.tranProcessor.Available - buyToApply;


            //Actualizo el Balance, flujo que permite ver el saldo de la tarjeta.
            motorDto.tranProcessor.Balance = motorDto.tranProcessor.Balance + buyToApply;


            //Si el tipo de Credito es un pago actualizamos la fecha y el numero de pago.
            if (motorDto.transactionsType.CreditCardTransactionsTypeKey == motorDto.TransactionBuy.CreditCardTransactionsTypeKey)
            {
                motorDto.tranProcessor.LastBillDate = motorDto.TranDto.DateTime.Value;
                motorDto.tranProcessor.LastBillNumber = motorDto.numOperationStr;
            }

            motorDto = await CreateProcessoDetail(motorDto);


            return motorDto;

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "ApplyDebit");
            motorDto.ErrorMessage = "Error al aplicar el débito. Reportar a equipo de soporte.";
            return motorDto;

        }

    }
    


    /// <summary>
    /// Metodo para aplicar Credito.
    /// </summary>
    /// <param name="motorDto"></param>
    /// <returns></returns>
    public static async Task<PayMotorDTO> ApplyCredit(PayMotorDTO motorDto)
    {
        try
        {

            decimal payToApply = motorDto.TranDto.Amount;
            decimal initialPay = motorDto.TranDto.Amount;

            //Identificamos si tienes monto a favor antes de aplciar el pago.
            if (motorDto.tranProcessor.Current < 0)
            {
                payToApply = payToApply + (motorDto.tranProcessor.Current * -1);
            }



            #region RegionPagos


                //120 DIAS
                //Cargos a los 120 dias
                if (payToApply >= motorDto.tranProcessor.Cargo120)
                {
                    payToApply = payToApply - motorDto.tranProcessor.Cargo120.Value;
                    motorDto.tranProcessor.Cargo120 = 0;
                }
                else
                {
                    motorDto.tranProcessor.Cargo120 = motorDto.tranProcessor.Cargo120 - payToApply;
                    payToApply = 0;
                }

                //Compras a los 120 dias
                if (payToApply >= motorDto.tranProcessor.Balance120)
                {
                    payToApply = payToApply - motorDto.tranProcessor.Balance120;
                    motorDto.tranProcessor.Balance120 = 0;
                }
                else
                {
                    motorDto.tranProcessor.Balance120 = motorDto.tranProcessor.Balance120 - payToApply;
                    payToApply = 0;
                }


                //90 DIAS
                //Cargos a los 90 dias
                if (payToApply >= motorDto.tranProcessor.Cargo90)
                {
                    payToApply = payToApply - motorDto.tranProcessor.Cargo90.Value;
                    motorDto.tranProcessor.Cargo90 = 0;
                }
                else
                {
                    motorDto.tranProcessor.Cargo90 = motorDto.tranProcessor.Cargo90 - payToApply;
                    payToApply = 0;
                }

                //Compras a los 90 dias
                if (payToApply >= motorDto.tranProcessor.Balance90)
                {
                    payToApply = payToApply - motorDto.tranProcessor.Balance90;
                    motorDto.tranProcessor.Balance90 = 0;
                }
                else
                {
                    motorDto.tranProcessor.Balance90 = motorDto.tranProcessor.Balance90 - payToApply;
                    payToApply = 0;
                }


                //60 DIAS
                //Cargos a los 60 dias
                if (payToApply >= motorDto.tranProcessor.Cargo60)
                {
                    payToApply = payToApply - motorDto.tranProcessor.Cargo60.Value;
                    motorDto.tranProcessor.Cargo60 = 0;
                }
                else
                {
                    motorDto.tranProcessor.Cargo60 = motorDto.tranProcessor.Cargo60 - payToApply;
                    payToApply = 0;
                }

                //Compras a los 60 dias
                if (payToApply >= motorDto.tranProcessor.Balance60)
                {
                    payToApply = payToApply - motorDto.tranProcessor.Balance60;
                    motorDto.tranProcessor.Balance60 = 0;
                }
                else
                {
                    motorDto.tranProcessor.Balance60 = motorDto.tranProcessor.Balance60 - payToApply;
                    payToApply = 0;
                }


                //30 DIAS
                //Cargos a los 30 dias
                if (payToApply >= motorDto.tranProcessor.Cargo30)
                {
                    payToApply = payToApply - motorDto.tranProcessor.Cargo30.Value;
                    motorDto.tranProcessor.Cargo30 = 0;
                }
                else
                {
                    motorDto.tranProcessor.Cargo30 = motorDto.tranProcessor.Cargo30 - payToApply;
                    payToApply = 0;
                }

                //Compras a los 30 dias
                if (payToApply >= motorDto.tranProcessor.Balance30)
                {
                    payToApply = payToApply - motorDto.tranProcessor.Balance30;
                    motorDto.tranProcessor.Balance30 = 0;
                }
                else
                {
                    motorDto.tranProcessor.Balance30 = motorDto.tranProcessor.Balance30 - payToApply;
                    payToApply = 0;
                }

            #endregion



            //Si hay acumulado de CARGOS en el mes, normalmente se acumula al final del mes si debe 
            if (payToApply >= motorDto.tranProcessor.Cargo)
            {
                payToApply = payToApply - motorDto.tranProcessor.Cargo.Value;
                motorDto.tranProcessor.Cargo = 0;
            }
            else
            {
                motorDto.tranProcessor.Cargo = motorDto.tranProcessor.Cargo - payToApply;
                payToApply = 0;
            }


            //Incrementamos el disponible.
            motorDto.tranProcessor.Available = motorDto.tranProcessor.Available + initialPay;


            //Actualizo el Balance, flujo que permite ver el saldo de la tarjeta.
            motorDto.tranProcessor.Balance = motorDto.tranProcessor.Balance - initialPay;

            if (motorDto.tranProcessor.Balance < 0)
            {
                motorDto.tranProcessor.Current = motorDto.tranProcessor.Balance;
            }

            //Actualizamos el pago minimo.
            if (motorDto.tranProcessor.MinimunPayment > 0)
            {
                if (motorDto.tranProcessor.MinimunPayment < initialPay)
                {
                    motorDto.tranProcessor.MinimunPayment = 0;
                }
                else
                {
                    motorDto.tranProcessor.MinimunPayment = motorDto.tranProcessor.MinimunPayment - initialPay;
                }
            }

            //Valor en deuda vencida
            if (motorDto.tranProcessor.AmountDue > 0)
            {
                if (motorDto.tranProcessor.AmountDue < initialPay)
                {
                    motorDto.tranProcessor.AmountDue = 0;
                }
                else
                {
                    motorDto.tranProcessor.AmountDue = motorDto.tranProcessor.AmountDue - initialPay;
                }
            }


            motorDto = await CreateProcessoDetail(motorDto);


            //Si el tipo de Credito es un pago actualizamos la fecha y el numero de pago.
            if (motorDto.transactionsType.CreditCardTransactionsTypeKey == motorDto.TransactionPay.CreditCardTransactionsTypeKey)
            {
                motorDto.tranProcessor.LastPayDate = motorDto.TranDto.DateTime.Value;
                motorDto.tranProcessor.LastPayNumber = motorDto.numOperationStr;
            }


            return motorDto;

        }
        catch (Exception e)
        {
            await ElasticAlert.LogErrorToElastic(e, "ApplyCredit");
            motorDto.ErrorMessage = "Error al aplicar el crédito. Reportar a equipo de soporte.";
            return motorDto; 
        }
    }






}

