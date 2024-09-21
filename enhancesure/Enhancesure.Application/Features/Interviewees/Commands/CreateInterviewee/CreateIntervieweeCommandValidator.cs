using FluentValidation;

namespace EnhanceSure.Application.Features.Interviewees.Commands.CreateInterviewee {
    public class CreateIntervieweeCommandValidator:AbstractValidator<CreateIntevieweeCommand> {
        public CreateIntervieweeCommandValidator()
        {
            RuleFor(r=>r.CreateIntervieweeDto.FirstName).NotNull().NotEmpty().WithMessage("{PropertyName} field is required.");
        }
    }
}
