using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardMasterStatusDTO
{


    public Guid CreditCardMasterStatusKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Description { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? Details { get; set; }

    [Column(TypeName = "char(1)")]
    public string? ExternalCode { get; set; }



    public bool? AllowDebit { get; set; }

    public bool? HasDebitAutorization { get; set; }

    public bool? AllowCredit { get; set; }

    public bool? HasCreditAutorization { get; set; }

    public bool? ReportAPC { get; set; }

    public Guid? APCMasterStatusKey { get; set; }

    public bool? HasReason { get; set; }

    public bool? FinalStatus { get; set; }

    public bool? IsSystem { get; set; }

    public bool? IsActive { get; set; }



    /// <summary>
    /// Campos de control
    /// </summary>
    public DateTime? Created { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public Guid? ModifiedBy { get; set; }


}