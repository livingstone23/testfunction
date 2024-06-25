using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0108;



public class CivilStatusDTO : BaseDomainModel
{


    public Guid CivilStatusKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Name { get; set; }


    [Column(TypeName = "NVARCHAR(150)")]
    public string? Description { get; set; }


}

