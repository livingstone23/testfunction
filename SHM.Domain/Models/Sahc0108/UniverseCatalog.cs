using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHM.Domain.Common;



namespace SHM.Domain.Models.Sahc0108;



[Table("UniverseCatalog", Schema = "Sahc0108")]
public class UniverseCatalog : BaseDomainModel
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

