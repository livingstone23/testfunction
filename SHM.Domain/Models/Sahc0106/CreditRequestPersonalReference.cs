using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;



namespace SHM.Domain.Models.Sahc0106;



[Table("CreditRequestPersonalReference", Schema = "Sahc0106")]
public class CreditRequestPersonalReference : BaseDomainModel
{


    [Key]
    public Guid CreditRequestPersonalReferenceKey { get; set; }
    

    [ForeignKey("CreditRequestMasterDetails")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CreditRequestMasterDetailKey { get; set; }
    [JsonIgnore]
    public CreditRequestMasterDetail CreditRequestMasterDetails { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(200)")]
    public string FullName { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(200)")]
    public string WorkPlace { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    [Column(TypeName = "NVARCHAR(50)")]
    public string Mobile { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? Email { get; set; }


}