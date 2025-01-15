using EnhanceSure.Domain.Entities;

namespace EnhanceSure.Domain.Common {
    public abstract class BaseEntity {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public Guid LastModifiedBy { get; set; }
        public void GenerateId()
        {
            this.Id = Guid.NewGuid();
        }
    }
    public class AuditUser: User {
        public Guid Id { get; set; }
        public DateTime Username { get; set; }
    }
}
