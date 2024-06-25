using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0108;



[Table("Province", Schema = "Sahc0108")]
public class Province : BaseDomainModel
{


    [Key]
    public Guid ProvinceKey { get; set; }


    [ForeignKey("Country")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? CountryKey { get; set; }


    public Country Country { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Name { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? Description { get; set; }


    //public IEnumerable<District> Districts { get; set; }

    //public IEnumerable<Township> Citys { get; set; }

}

