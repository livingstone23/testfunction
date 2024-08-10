using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Dto.Sahc0106;



public class CatalogGenericDTO
{


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

public class CatalogGenericToDropDownDTO
{

    public Guid   CatalogKey { get; set; }
    public string Name { get; set; }

    public string? Description { get; set; }

}

