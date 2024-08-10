using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Common;
using SHM.Domain.Models.Sahc0106;
using SHM.Domain.Models.Sahc0108;



namespace SHM.Domain.Models.Sahc0100;



[Table("EntityMasterAddress", Schema = "Sahc0100")]
public class EntityMasterAddress : BaseDomainModel
{


    [Key]
    public Guid EntityMasterAddressKey { get; set; }


    [ForeignKey("EntityMasterGeneral")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? EntityMasterGeneralKey { get; set; }
    public EntityMasterGeneral EntityMasterGeneral { get; set; }


    [ForeignKey("Countries")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CountryKey { get; set; }
    public Country Countries { get; set; }


    [ForeignKey("Provinces")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? ProvinceKey { get; set; }
    public Province Provinces { get; set; }


    [ForeignKey("Districts")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? DistrictKey { get; set; }
    public District Districts { get; set; }


    [ForeignKey("Townships")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? TownshipKey { get; set; }
    public Township Townships { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string AddressName { get; set; }


    [ForeignKey("SourceMasters")]
    public Guid? SourceMasterKey { get; set; }
    public SourceMaster SourceMasters { get; set; }

    
    [ForeignKey("EntityMasterAddresstypes")]
    public Guid? EntityMasterAddressTypeKey { get; set; }
    public EntityMasterAddressType EntityMasterAddresstypes { get; set; }


    public virtual ICollection<CreditRequestMasterDetail> CreditRequestsMasterDetails { get; set; } = new List<CreditRequestMasterDetail>();

}

