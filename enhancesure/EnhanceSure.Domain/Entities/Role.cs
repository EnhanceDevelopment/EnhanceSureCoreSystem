using EnhanceSure.Domain.Common;

namespace EnhanceSure.Domain.Entities {
    public class Role:BaseEntity {
        public string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
