namespace EnhanceSure.Application.DTOs.Users.ChangePasswords {
    public class ChangePasswordCommandDto {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
