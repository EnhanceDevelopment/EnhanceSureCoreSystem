using EnhanceSure.Application.DTOs.Users.ChangePasswords;
using EnhanceSure.Application.Shared.Request;

namespace EnhanceSure.Application.Features.Users.ChangePasswords.Commands {
    public class ChangePasswordCommand: AppRequest<ChangePasswordResponseDto> {
        public ChangePasswordCommandDto ChangePasswordCommandDto { get; set; }
    }
}
