using SHM.Domain.Common;
using SHM.Domain.Models.Sahc0109;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0108;



[Table("CivilStatus", Schema = "Sahc0108")]
public class CivilStatus : BaseDomainModel
{

    [Key]
    public Guid CivilStatusKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Name { get; set; }


    [Column(TypeName = "NVARCHAR(150)")]
    public string? Description { get; set; }

    // Navigation property
    public virtual ICollection<TranslationCatalog> TranslationCatalogs { get; set; }

}

