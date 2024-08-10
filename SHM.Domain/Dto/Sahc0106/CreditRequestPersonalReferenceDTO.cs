using SHM.Domain.Common;
using SHM.Domain.Models.Sahc0106;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace SHM.Domain.Dto.Sahc0106;



public class CreditRequestPersonalReferenceDTO : BaseDomainModel
{

    public Guid CreditRequestPersonalReferenceKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CreditRequestMasterDetailKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(200)")]
    public string FullName { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(200)")]
    public string WorkPlace { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(50)")]
    public string Mobile { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? Email { get; set; }

}