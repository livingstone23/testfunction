using SHM.Domain.Common;
using SHM.Domain.Models.Sahc0100;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Models.Sahc0108;

namespace SHM.Domain.Models.Sahc0109;



[Table("TranslationCatalog", Schema = "Sahc0108")]
public class TranslationCatalog : BaseDomainModel
{


    [Key]
    public Guid TranslationCatalogKey { get; set; }


    [ForeignKey("LanguageCode")]
    public Guid? LanguageCodeKey { get; set; }
    public LanguageCode LanguageCode { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Catalog { get; set; }
    


    public Guid? ReferenceKey { get; set; }



    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string RenderValue { get; set; }

    [Column(TypeName = "NVARCHAR(250)")]
    public string? Description { get; set; }


    [ForeignKey("ReferenceKey")]
    public virtual RelationshipType RelationshipType { get; set; }

    [ForeignKey("ReferenceKey")]
    public virtual CivilStatus CivilStatus { get; set; }

}