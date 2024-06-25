using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace SHM.Domain.Dto.Sahc0106;



public class CreditCardStatusDTO
{


    public Guid CreditCardStatusKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(50)")]
    public string Description { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? Details { get; set; }

    [Column(TypeName = "CHAR(1)")]
    public string? ExternalCode { get; set; }

    public bool? AllowDebit { get; set; }

    public bool? AllowCredit { get; set; }



    public bool? FinalStatus { get; set; }
    public bool? IsSystem { get; set; }
    public bool? IsActive { get; set; }


    
    //Campos de control
    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }


}