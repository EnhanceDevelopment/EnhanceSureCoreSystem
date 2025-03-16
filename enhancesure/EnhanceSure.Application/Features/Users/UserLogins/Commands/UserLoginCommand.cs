using EnhanceSure.Application.DTOs.Users.UserLogins;
using EnhanceSure.Application.Shared.Request;

namespace EnhanceSure.Application.Features.Users.UserLogins.Commands {
    public class UserLoginCommand:AppRequest<UserLoginResponseDto> {
        public UserLoginCommandDto? UserLoginCommandDto{ get; set; }
    }
}
