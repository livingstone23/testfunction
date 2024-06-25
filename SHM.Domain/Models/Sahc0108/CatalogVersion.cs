using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0108;



[Table("CatalogVersion", Schema = "Sahc0108")]
public class CatalogVersion : BaseDomainModel
{

    [Key]
    public Guid CatalogVersionKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Catalog { get; set; }


    [Column(TypeName = "NVARCHAR(20)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Version { get; set; }

}


