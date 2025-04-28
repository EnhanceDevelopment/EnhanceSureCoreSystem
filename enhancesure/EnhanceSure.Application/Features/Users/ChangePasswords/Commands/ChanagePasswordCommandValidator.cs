using EnhanceSure.Application.Shared.Extensions;
using EnhanceSure.Domain.Interfaces;
using FluentValidation;

namespace EnhanceSure.Application.Features.Users.ChangePasswords.Commands {
    public class ChanagePasswordCommandValidator: AbstractValidator<ChangePasswordCommand> {
        public ChanagePasswordCommandValidator(IDbConnectionFactory connection)
        {
            RuleFor(r => r.ChangePasswordCommandDto.Email)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} field is required.");

            RuleFor(r => r.ChangePasswordCommandDto.OldPassword)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} field is required.");

            RuleFor(r => r.ChangePasswordCommandDto.NewPassword)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} field is required.")
                .MinimumLength(8).WithMessage("Enter atleast 8 chanracter.");

            RuleFor(r => r.ChangePasswordCommandDto.ConfirmPassword)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} field is required.")
                .Equal(x => x.ChangePasswordCommandDto.NewPassword).WithMessage("Passwords do not match.");

            RuleFor(r => r.ChangePasswordCommandDto.Email).DoesEmailExists(connection);
        }
    }
}
