using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Common;
using SHM.Domain.Dto.Sahc0106;
using SHM.Domain.Models.Sahc0106;


namespace SHM.Domain.Dto.Sahc0100;



public class EntityMasterAddressDTO: BaseDomainModel
{


    public Guid EntityMasterAddressKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? EntityMasterGeneralKey { get; set; }



    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CountryKey { get; set; }
    public string? CountryName { get; set; }



    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? ProvinceKey { get; set; }
    public string? ProvinceName { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? DistrictKey { get; set; }
    public string? DistrictName { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? TownshipKey { get; set; }
    public string? TownshipName { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string AddressName { get; set; }


    public Guid? SourceMasterKey { get; set; }
    public string? SourceMasterName { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? EntityMasterAddressTypeKey { get; set; }
    public string? EntityMasterAddressTypeName { get; set; }


    public virtual ICollection<CreditRequestMasterDetailDTO> CreditRequestsMasterDetailDTOs { get; set; } = new List<CreditRequestMasterDetailDTO>();


}