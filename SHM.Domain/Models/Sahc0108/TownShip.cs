using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Models.Sahc0108;



namespace SHM.Domain.Models.Sahc0108;



[Table("Township", Schema = "Sahc0108")]
public class Township : BaseDomainModel
{
    

    [Key]
    public Guid TownshipKey { get; set; }


    [ForeignKey("District")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid? DistrictKey { get; set; }


    public District District { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Name { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    public string? Description { get; set; }
    
    
    //public IEnumerable<PostalCodeByCity> PostalCodeByCities { get; set; }


}

