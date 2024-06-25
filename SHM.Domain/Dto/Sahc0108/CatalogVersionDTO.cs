using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0108;



public class CatalogVersionDTO
{

    public Guid CatalogVersionKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Catalog { get; set; }


    [Column(TypeName = "NVARCHAR(20)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Version { get; set; }

}

