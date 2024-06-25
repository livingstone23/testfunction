using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0100;



[Table("EntityMasterAddressType", Schema = "Sahc0100")]
public class EntityMasterAddressType
{


    [Key]
    public Guid EntityMasterAddressTypeKey { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Id { get; set; }

    [Column(TypeName = "NVARCHAR(150)")]
    [Required(ErrorMessage = "El {0} es un campo requerido. ")]
    public string Description { get; set; }

    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }
     

}