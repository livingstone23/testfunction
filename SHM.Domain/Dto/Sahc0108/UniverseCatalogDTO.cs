using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0108;



public class UniverseCatalogDTO : BaseDomainModel
{

    [Key]
    public Guid UniverseCatalogKey { get; set; }


    public Guid? LanguageCodeKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Catalog { get; set; }


    public Guid? ReferenceKey { get; set; }


    [Column(TypeName = "NVARCHAR(100)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string RenderValue { get; set; }


    [Column(TypeName = "NVARCHAR(250)")]
    public string? Description { get; set; }


    [Column(TypeName = "NVARCHAR(20)")]
    public string? TableVersion { get; set; }


}

public class CatalogDropDownDTO
{
    public Guid? ReferenceKey { get; set; }

    public string RenderValue { get; set; }


    public string? TableVersion { get; set; }

}

