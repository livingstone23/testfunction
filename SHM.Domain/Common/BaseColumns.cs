using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Common
{
    public class BaseColumns
    {

        [Column(TypeName = "datetime")]
        public DateTime? Created { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Modified { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid? ModifiedBy { get; set; }
    }
}