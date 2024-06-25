using SHM.Domain.Models.Sahc0100;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Models.Sahc0106;

[Table("EntityMasterGeneralPLCC", Schema = "Sahc0106")]
public class EntityMasterGeneralPLCC {


    [Key]
    public Guid EntityMasterGeneralPLCCKey { get; set; }

    [ForeignKey("EntityMasterGeneral")]
    public Guid EntityMasterGeneralKey { get; set; }

    public Guid? AssignedAgent { get; set; }
    public Guid? AssignedAgency { get; set; }

    public DateTime? ApcDate { get; set; }

    public bool HighRisk { get; set; }

    public DateTime? ArrangementDate { get; set; }

    public string Comments { get; set; }

    public int? StatementDeliveryMethod { get; set; }

    public DateTime Created { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public string ModifiedBy { get; set; }

    public bool SendAccountStatement { get; set; }

    // Navigation properties
    public virtual EntityMasterGeneral EntityMasterGeneral { get; set; }


}