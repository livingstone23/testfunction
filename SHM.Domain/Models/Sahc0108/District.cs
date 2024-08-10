using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0108;



[Table("District", Schema = "Sahc0108")]
public class District : BaseDomainModel
{


    [ForeignKey("Province")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? ProvinceKey { get; set; }


    public Province Province { get; set; }


    [Key]
    public Guid DistrictKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Name { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? Description { get; set; }
    

    //[ForeignKey("Country")]
    //[Required(ErrorMessage = "El {0} es un campo requerido. ")]
    //public Guid? CountryKey { get; set; }
    //public Country Country { get; set; }
    //public IEnumerable<Township> TowhShips { get; set; }


}


