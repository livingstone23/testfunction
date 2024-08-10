using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace SHM.Domain.Dto.Sahc0108;



public class SourceMasterDTO : BaseDomainModel
{


    public Guid SourceMasterKey { get; set; }


    public string Id { get; set; }


    [Column(TypeName = "NVARCHAR(150)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? Description { get; set; }


}