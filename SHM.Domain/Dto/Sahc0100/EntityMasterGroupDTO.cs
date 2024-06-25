using SHM.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Dto.Sahc0100
{
    [Table("EntityMasterGroup", Schema = "Sahc0100")]
    public class EntityMasterGroup : BaseColumns
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid EntityMasterGroupKey { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(5)")]
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Description { get; set; }

    }

}

