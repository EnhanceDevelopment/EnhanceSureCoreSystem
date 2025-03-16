using EnhanceSure.Application.DTOs.Users.RegisterUsers;
using FluentValidation;

namespace EnhanceSure.Application.Features.Users.RegisterUsers.Commands {
    public class RegisterUserCommandValidator: AbstractValidator<RegisterUserDto> {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.ConfirmPassword)
                .Equal(i => i.Password).WithMessage("Password didn't matched.");
            RuleFor(r => r.Email)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        }
    } 
}
