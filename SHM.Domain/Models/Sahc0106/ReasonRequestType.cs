using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0106;



[Table("ReasonRequestType", Schema = "Sahc0106")]
public class ReasonRequestType
{

    [Key]
    public Guid ReasonRequestTypeKey { get; set; }

    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Id { get; set; }

    [Column(TypeName = "NVARCHAR(150)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Description { get; set; }

    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }

}