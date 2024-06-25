using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SHM.Domain.Models.Sahc0100;


[Table("EntityMasterGroup", Schema = "Sahc0100")]
public class EntityMasterGroup
{

    [Key]
    public Guid EntityMasterGroupKey { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Modified { get; set; }

    [Column(TypeName = "NVARCHAR(5)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Id { get; set; }

    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Description { get; set; }


}

