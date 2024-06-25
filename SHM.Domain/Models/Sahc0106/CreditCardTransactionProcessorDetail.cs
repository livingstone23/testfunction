using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0106;



[Table("CreditCardTransactionProcessorDetail", Schema = "Sahc0106")]
public class CreditCardTransactionProcessorDetail
{


    [Key]
    public Guid CreditCardTransactionProcessorDetailKey { get; set; }


    [ForeignKey("CreditCardTransactionProcessor")]
    public Guid CreditCardTransactionProcessorKey { get; set; }
    public CreditCardTransactionProcessor CreditCardTransactionProcessor { get; set; }


    [Column(TypeName = "NVARCHAR(10)")]
    public string TypeMovement { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public Decimal Value { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal Balance { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string StoreId { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string PostId { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string UserId { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string CardNumber { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string CodClient { get; set; }

    [Column(TypeName = "NVARCHAR(100)")]
    public string Message { get; set; }



    [Column(TypeName = "NVARCHAR(50)")]
    public string ApprovalNumber { get; set; }
    
    [Column(TypeName = "NVARCHAR(50)")]
    public string? TransactionNumber { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? EmailMessageId { get; set; }

    public bool IsReverted { get; set; } = false;

    [Column(TypeName = "date")]
    public DateTime DateField { get; set; }

    [Column(TypeName = "time")]
    public TimeSpan TimeField { get; set; }



    public Guid? CatalogGenericKey { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? ReasonDescription { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? Comment { get; set; }






    //Nuevos campos
    public Guid? BranchMasterGeneralKey { get; set; }
    public Guid? CreditCardTransactionTypeKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? CodExterno { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExecutingSystem { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExecutingSystemTransactionId { get; set; }
    [Column(TypeName = "NVARCHAR(50)")]
    public string? ExecutingSystemTransactionKey { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? DocEntry { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Terminal { get; set; }

    public Guid? ExecutingSystemGeneralKey { get; set; }






    //Campos de control.
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }


}

