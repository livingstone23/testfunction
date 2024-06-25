using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Dto.dbo;

public class MasterCreditItemAddressDTO : BaseDomainModel
{
    public MasterCreditItemAddressDTO()
    {
        Active = true;
    }

    public Guid MasterCreditItemAddressKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid MasterCreditItemKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? ProvinceKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? DistrictKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? TownshipKey { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string AddressName { get; set; }


    //public bool IsMain { get; set; }


}