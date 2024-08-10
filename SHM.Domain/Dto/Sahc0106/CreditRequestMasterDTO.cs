using SHM.Domain.Common;
using SHM.Domain.Models.Sahc0106;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0106;



public class CreditRequestMasterDTO : BaseDomainModel
{

    public Guid CreditRequestMasterKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? EntityMasterGeneralKey { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? RequestNumber { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? ReasonRequestTypeKey { get; set; }

    public string ReasonRequestTypeName { get; set; }


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


    public ICollection<CreditRequestMasterDetailDTO> CreditRequestMasterDetailDTOs { get; set; } = new List<CreditRequestMasterDetailDTO>();


}