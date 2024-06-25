using SHM.Domain.Models.Sahc0106;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardTranProcessorCycleDTO
{



    public Guid CreditCardTransactionProcessorCycleKey { get; set; }

    /// <summary>
    /// Llave foranea de la tabla CreditCardMasterGeneral
    /// </summary>
    public Guid CreditCardMasterGeneralKey { get; set; }

    [ForeignKey("CreditCardMasterGeneralKey")]
    public CreditCardMasterGeneral CreditCardMasterGenerals { get; set; }


    /// <summary>
    /// Llave foranea de la tabla BillingCycleMaster
    /// </summary>
    public Guid BillingCycleMasterKey { get; set; }

    [ForeignKey("BillingCycleMasterKey")]
    public BillingCycleMaster BillingCycleMasters { get; set; }





    /// <summary>
    /// Fecha para registrar el último pago realizado
    /// </summary>
    public DateTime? LastPayDate { get; set; }

    /// <summary>
    /// Campo para registrar el ultimo numero de pago
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? LastPayNumber { get; set; }

    /// <summary>
    /// Fecha para registrar el ultimo numero de factura
    /// </summary>
    public DateTime? LastBillDate { get; set; }

    /// <summary>
    /// Campo para registar el último numero de factura
    /// </summary>
    [Column(TypeName = "NVARCHAR(50)")]
    public string? LastBillNumber { get; set; }





    /// <summary>
    /// Campo para registrar el limite de la tarjeta
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal CreditLimit { get; set; }

    /// <summary>
    /// Campo para registrar el disponible de la tarjeta
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Available { get; set; }

    /// <summary>
    /// Campo para registrar en cuanto se encuentra el inicio de la deuda
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal OpeningBalance { get; set; }     //Pago minimo

    /// <summary>
    /// Campo para registrar el pago minimo
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal MinimunPayment { get; set; }     //Pago minimo

    /// <summary>
    /// Deuda actual incluye las compras a la fecha actual mas los cargos.
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Current { get; set; }

    /// <summary>
    /// Monto de la deuda vencido a la fecha.
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal AmountDue { get; set; }


    /// <summary>
    /// Total de pagos realizados en el mes,
    /// sin incluir los movimientos de ajustes.
    /// ejemplo reversiones de compras.
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal? TotalPays { get; set; }

    /// <summary>
    /// Total de compras en el mes, sin incluir los movimientos de ajustes.
    /// ejemplo reversion de pagos.
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal? TotalPurchases { get; set; }     //Total Compras



    ////Manejo compras
    /// Acumuado de las compras en el periodo
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Balance { get; set; }

    /// <summary>
    /// Saldo de las compras pendiente de pagar a los 30 dias
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Balance30 { get; set; }

    /// <summary>
    /// Saldo de las compras pendiente de pagar a los 60 dias
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Balance60 { get; set; }

    /// <summary>
    /// Saldo de las compras pendiente de pagar a los 90 dias
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Balance90 { get; set; }

    /// <summary>
    /// Saldo de las compras pendiente de pagar a los 120 dias
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Balance120 { get; set; }



    ////Manejo de cargos
    /// <summary>
    /// Acumulado de los cargos a la fecha
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Charges { get; set; }

    /// <summary>
    /// Acumulado de los cargos a 30 dias
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Charges30 { get; set; }

    /// <summary>
    /// Acumulado de los cargos a 60 dias
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Charges60 { get; set; }

    /// <summary>
    /// Acumulado de los cargos a 90 dias
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Charges90 { get; set; }

    /// <summary>
    /// Acumulado de los cargos a 120 dias
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Charges120 { get; set; }




    //Manejo de Saldos plan de pago
    /// <summary>
    /// Campo para registrar el monto de la deuda del plan de pago.
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal? PaymentPlanDebt { get; set; }

    /// <summary>
    /// Campo para registrar el monto de la deuda a la fecha actual
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal? PaymentPlanDebtDate { get; set; }

    /// <summary>
    /// Campo para registrar el saldo a la fecha del plan
    /// </summary>
    [Column(TypeName = "decimal(18, 4)")]
    public decimal? PaymentPlanBalance { get; set; }




    //Campos de control.
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }



}

