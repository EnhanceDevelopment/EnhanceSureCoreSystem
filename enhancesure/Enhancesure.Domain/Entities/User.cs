using EnhanceSure.Domain.Common;
using EnhanceSure.Domain.Enums;

namespace EnhanceSure.Domain.Entities {
    public class User:BaseEntity {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public UserStatus Status { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public IList<UserRole> UserRoles { get; set; }
    }
}
