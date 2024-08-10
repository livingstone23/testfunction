using SHM.Domain.Common;
using SHM.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SHM.Domain.Dto.dbo;

public class MasterCreditItemPersonalReferenceDTO : BaseDomainModel
{

    public MasterCreditItemPersonalReferenceDTO()
    {
        Active = true;
    }

    public Guid MasterCreditItemPersonalReferenceKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid MasterCreditItemKey { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string FullName { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string WorkPlace { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Mobile { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Email { get; set; }

}