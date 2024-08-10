using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SHM.Domain.Dto.Sahc0106;


public class CreditCardTransactionsDTO
{


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CreditCardTransactionKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(100)")]
    public Guid? CreditCardMasterGeneralKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(50)")]
    public string OriginSystem { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(50)")]
    public string TransactionNumber { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [StringLength(2)]
    public string TransactionsType { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [StringLength(10)]
    public string CreditDebit { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(50)")]
    public decimal Amount { get; set; }


    public Guid? CreditCardCreditPlanKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "decimal(18, 4)")]


    public decimal InitialPay { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "decimal(18, 4)")]
    public decimal TotalPay { get; set; }


    [StringLength(50)]
    public string? MainCreditCardKey { get; set; }


    [StringLength(50)]
    public string? BaseCreditCardTransactionKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid CreditCardTransactionsTypeKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? Store { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? Cashier { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? CodExterno { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? CreditCardNumber { get; set; }


    public int? Num { get; set; }


    [Column(TypeName = "NVARCHAR(250)")]
    public string? Description { get; set; }


    [Column(TypeName = "decimal(18, 4)")]
    public decimal? Balance { get; set; }
    




    /// <summary>
    /// Campos agregados en 2024/Abril 
    /// </summary>
    //[Column(TypeName = "NVARCHAR(250)")]
    //public string? Details { get; set; }

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
    



    
    //Campos de control
    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }


}