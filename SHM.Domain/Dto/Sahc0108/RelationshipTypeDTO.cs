using System.ComponentModel.DataAnnotations;
using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Dto.Sahc0108;



public class RelationshipTypeDTO : BaseDomainModel
{

    public Guid RelationshipTypeKey { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Name { get; set; }


    [Column(TypeName = "NVARCHAR(150)")]
    public string? Description { get; set; }


}

