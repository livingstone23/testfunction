
namespace SHM.Domain.Common {
    public class StandardColumns {
        public bool? IsActive { get; set; }
        public bool? IsSystem { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}