using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SHM.Domain.Models.Sahc0104 {

    [Table("ReportGroup", Schema = "Sahc0104")]
    public class ReportGroup {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid ReportGroupKey { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(250)")]
        public string Detail { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }

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
