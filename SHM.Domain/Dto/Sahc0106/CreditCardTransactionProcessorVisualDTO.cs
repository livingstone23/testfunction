using SHM.Domain.Models.Sahc0106;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Dto.Sahc0106;



/// <summary>
/// Clase visual que permite presentar el motor de credito
/// </summary>
public class CreditCardTransactionProcessorVisualDTO
{


    public Guid CreditCardTransactionProcessorKey { get; set; }

    public Guid CreditCardMasterGeneralKey { get; set; }

    public Guid CreditCardBalanceKey { get; set; }



    //Datos de compras
    public DateTime? LastPayDate { get; set; }
    public string? LastPayNumber { get; set; }

    //Datos de Pagos
    public DateTime? LastBillDate { get; set; }
    public string? LastBillNumber { get; set; }



    public decimal CreditLimit { get; set; }
    public decimal Available { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal MinimunPayment { get; set; }
    
    public decimal AmountDue { get; set; }
    public decimal Current { get; set; }

    //Equivalente a tener el balance del saldo,
    //la otra columna de balance tiene el acumulativo
    //de las deudas a la fecha 
    public decimal BalancePlan { get; set; }


    //Datos de pagos acumulativos en el mes
    public decimal? TotalPays { get; set; }
    //Datos de compras acumulativas en el mes
    public decimal? TotalPurchases { get; set; }


    //Maneja el saldo a la fecha.
    public decimal Balance { get; set; }
    public decimal Balance30 { get; set; }
    public decimal Balance60 { get; set; }
    public decimal Balance90 { get; set; }
    public decimal Balance120 { get; set; }


    //public void AssignValues(CreditCardTransactionProcessor tranProcessor)
    //{
    //    //PENDIENTE DEFINIR ESTE VALOR.
    //    this.Balance  = tranProcessor.Balance + tranProcessor.Current;

    //    this.Balance30 = tranProcessor.Balance30 + tranProcessor.Charges30;
    //    this.Balance60 = tranProcessor.Balance60 + tranProcessor.Charges60;
    //    this.Balance90 = tranProcessor.Balance90 + tranProcessor.Charges90;
    //    this.Balance120 = tranProcessor.Balance120 + tranProcessor.Charges120;






    //}





}

