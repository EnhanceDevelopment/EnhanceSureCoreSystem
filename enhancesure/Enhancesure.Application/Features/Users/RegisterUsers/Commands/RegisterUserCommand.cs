using EnhanceSure.Application.DTOs.Users.RegisterUsers;
using EnhanceSure.Application.Shared.Request;
using MediatR;

namespace EnhanceSure.Application.Features.Users.RegisterUsers.Commands {
    public class RegisterUserCommand : AppRequest<Unit>{
        public RegisterUserDto RegisterUserDto { get; set; }
    }
}
