using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Models.Dto;

[Table("MasterCreditItemPersonalReference")]
public class MasterCreditItemPersonalReference : BaseDomainModel
{


    [Key]
    public Guid MasterCreditItemPersonalReferenceKey { get; set; }


    [ForeignKey("MasterCreditItem")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public Guid MasterCreditItemKey { get; set; }


    public MasterCreditItem MasterCreditItem { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string FullName { get; set; }


    [Column(TypeName = "NVARCHAR(200)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? WorkPlace { get; set; }


    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Mobile { get; set; }


    [EmailAddress]
    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string? Email { get; set; }




}