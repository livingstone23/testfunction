using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHM.Domain.Models.Sahc0104 {

    [Table("ReportMaster", Schema = "Sahc0104")]
    public class ReportMaster {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid ReportKey { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")] 
        public string Description { get; set; }

        [Column(TypeName = "NVARCHAR(250)")]
        public string? Detail { get; set; }

        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid ReportGroupKey { get; set; }

        [Column(TypeName = "text")]
        public string? ReportSource { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string? DbUser { get; set; }

        [Column(TypeName = "NVARCHAR(250)")]
        public string? DbPassword { get; set; }

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
