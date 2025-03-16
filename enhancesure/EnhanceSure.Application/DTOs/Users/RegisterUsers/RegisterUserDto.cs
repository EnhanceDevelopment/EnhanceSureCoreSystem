using EnhanceSure.Application.DTOs.Common;

namespace EnhanceSure.Application.DTOs.Users.RegisterUsers {
    public class RegisterUserDto: BaseDto {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

    }
}
