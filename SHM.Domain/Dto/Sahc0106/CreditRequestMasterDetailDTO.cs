using SHM.Domain.Common;
using SHM.Domain.Models.Sahc0106;
using System.ComponentModel.DataAnnotations;
using SHM.Domain.Models.Sahc0100;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Dto.Sahc0100;

namespace SHM.Domain.Dto.Sahc0106;

public class CreditRequestMasterDetailDTO : BaseDomainModel
{


    public Guid CreditRequestMasterDetailKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CreditRequestMasterKey { get; set; }
    

    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? EntityMasterGeneralKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? RelationshipTypeKey { get; set; }

    public string? RelationshipTypeName { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public bool Colateral { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public bool AditionalCard { get; set; }


    public virtual ICollection<CreditRequestPersonalReferenceDTO>? CreditRequestPersonalReferencesDTO { get; set; } = new HashSet<CreditRequestPersonalReferenceDTO>();

    public virtual ICollection<CreditRequestWorkingInformationDTO>? CreditRequestWorkingInformationsDTO { get; set; } = new List<CreditRequestWorkingInformationDTO>();


    public Guid? EntityMasterAddressKey { get; set; }
    public virtual EntityMasterAddressDTO EntityMasterAddressDTO { get; set; }


}

