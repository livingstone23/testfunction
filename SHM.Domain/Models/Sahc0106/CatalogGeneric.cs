using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SHM.Domain.Models.Sahc0106;



[Table("CatalogGeneric", Schema = "Sahc0106")]
public class CatalogGeneric
{

    [Key]
    public Guid CatalogGenericKey { get; set; }

    public Guid? ParentCatalogKey { get; set; }

    [Column(TypeName = "NVARCHAR(100)")]
    public string Name { get; set; }

    [Column(TypeName = "NVARCHAR(100)")]
    public string Description { get; set; }

    public bool? Active { get; set; }



    //Campos de control
    public DateTime? Created { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public Guid? ModifiedBy { get; set; }


}

