using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0108;



[Table("LanguageCode", Schema = "Sahc0108")]
public class LanguageCode
{


    [Key]
    public Guid LanguageCodeKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Code { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Description { get; set; }


    public DateTime? Created { get; set; }


    public Guid? CreatedBy { get; set; }


    public DateTime? Modified { get; set; }


    public Guid? ModifiedBy { get; set; }


}