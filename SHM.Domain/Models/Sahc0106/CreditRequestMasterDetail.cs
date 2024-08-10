using SHM.Domain.Common;
using SHM.Domain.Models.Sahc0100;
using SHM.Domain.Models.Sahc0108;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0106;



[Table("CreditRequestMasterDetail", Schema = "Sahc0106")]
public class CreditRequestMasterDetail : BaseDomainModel
{


    [Key]
    public Guid CreditRequestMasterDetailKey { get; set; }


    [ForeignKey("CreditRequestMasters")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CreditRequestMasterKey { get; set; }
    public CreditRequestMaster CreditRequestMasters { get; set; }


    [ForeignKey("EntityMasterGenerals")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? EntityMasterGeneralKey { get; set; }
    public EntityMasterGeneral EntityMasterGenerals { get; set; }
    

    [ForeignKey("RelationshipTypes")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? RelationshipTypeKey { get; set; }
    public RelationshipType RelationshipTypes { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public bool Colateral { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public bool AditionalCard { get; set; }

    public virtual ICollection<CreditRequestPersonalReference>? CreditRequestPersonalReferences { get; set; } = new List<CreditRequestPersonalReference>();

    public virtual ICollection<CreditRequestWorkingInformation>? CreditRequestWorkingInformations { get; set; } = new List<CreditRequestWorkingInformation>();



    [ForeignKey("EntityMasterAddres")]
    public Guid? EntityMasterAddressKey { get; set; }
    public EntityMasterAddress EntityMasterAddres { get; set; }



}