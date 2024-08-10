using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SHM.Domain.Models.Sahc0100;



[Table("EntityMasterExternalReference", Schema = "Sahc0100")]
public class EntityMasterExternalReference
{

    [Key]
    public Guid EntityMasterExternalReferenceKey { get; set; }

    [ForeignKey("EntityMasterGenerals")]
    public Guid EntityMasterGeneralKey { get; set; }

    public EntityMasterGeneral EntityMasterGenerals { get; set; }
    
    public Guid EntityMasterExternalReferencesystemsKey { get; set; }
    
    public string? Id { get; set; }

}

