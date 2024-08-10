using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardTransactionProcessorLogDTO
{
    

    public Guid CreditCardTransactionProcessorLogKey { get; set; }
    public Guid CreditCardTransactionProcessorKey { get; set; }



    //Datos para revertir
    //Datos de compras
    public DateTime? LastPayDate { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? LastPayNumber { get; set; }
    //Datos de Pagos
    public DateTime? LastBillDate { get; set; }
    [Column(TypeName = "NVARCHAR(50)")]
    public string? LastBillNumber { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal CreditLimit { get; set; }        //Limit
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Available { get; set; }          //Disponible
    [Column(TypeName = "decimal(18, 4)")]
    public decimal Balance { get; set; }            //Saldo
    [Column(TypeName = "decimal(18, 4)")]
    public decimal MinimunPayment { get; set; }     //Pago minimo



    //Campos de control.
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }



}

