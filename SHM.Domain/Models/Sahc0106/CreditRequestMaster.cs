using SHM.Domain.Common;
using SHM.Domain.Models.Sahc0100;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0106;



[Table("CreditRequestMaster", Schema = "Sahc0106")]
public class CreditRequestMaster: BaseDomainModel
{


    [Key]
    public Guid CreditRequestMasterKey { get; set; }


    [ForeignKey("EntityMasterGenerals")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? EntityMasterGeneralKey { get; set; }
    public EntityMasterGeneral EntityMasterGenerals { get; set; }
    

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? RequestNumber { get; set; }


    [ForeignKey("ReasonRequestTypes")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? ReasonRequestTypeKey { get; set; }
    public ReasonRequestType ReasonRequestTypes { get; set; }


    [Column(TypeName = "NVARCHAR(255)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Comments { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public bool? VerifiedSignature { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? ReviewedBy { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? ApprovedBy { get; set; }


    public DateTime? ApprovalDate { get; set; }


    public ICollection<CreditRequestMasterDetail> CreditRequestMasterDetails { get; set; } = new List<CreditRequestMasterDetail>();


}