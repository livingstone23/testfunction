using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace SHM.Domain.Dto.Sahc0109;



public class TranslationCatalogDTO : BaseDomainModel
{

    [Key]
    public Guid TranslationCatalogKey { get; set; }


    public Guid? LanguageCodeKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Catalog { get; set; }


    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? ReferenceKey { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string RenderValue { get; set; }


    [Column(TypeName = "NVARCHAR(250)")]
    public string? Description { get; set; }


}

public class TranslationCatalogDropDownDTO
{

    public Guid? ReferenceKey { get; set; }

    public string RenderValue { get; set; }

}