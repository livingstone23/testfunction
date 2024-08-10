using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHM.Domain.Common;


namespace SHM.Domain.Dto.Sahc0108;



public class DistrictDTO: BaseDomainModel
{


    public Guid DistrictKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Name { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? Description { get; set; }



    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid ProvinceKey { get; set; }


}

