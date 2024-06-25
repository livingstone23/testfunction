using SHM.Domain.Common;
using SHM.Domain.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Models.Sahc0108;

namespace SHM.Domain.Models.Dto;


[Table("MasterCreditItemAddress")]
public class MasterCreditItemAddress : BaseDomainModel
{

    public MasterCreditItemAddress()
    {
        Active = true;
        Created = TimeZoneHelperTest.GetPanamaTime();
    }


    [Key]
    public Guid MasterCreditItemAddressKey { get; set; }


    [ForeignKey("MasterCreditItem")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid MasterCreditItemKey { get; set; }


    public MasterCreditItem MasterCreditItem { get; set; }


    [ForeignKey("Province")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? ProvinceKey { get; set; }


    public Province Province { get; set; }


    [ForeignKey("District")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? DistrictKey { get; set; }


    public District District { get; set; }


    [ForeignKey("Township")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? TownshipKey { get; set; }


    public Township Township { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string AddressName { get; set; }


    //public bool IsMain { get; set; }



}



