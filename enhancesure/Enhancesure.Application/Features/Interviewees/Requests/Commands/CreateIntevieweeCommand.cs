using BindraSawMill.Application.Shared.Request;
using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Domain.Entities;
using MediatR;

namespace EnhanceSure.Application.Features.Interviewees.Requests.Command {
    public class CreateIntevieweeCommand: AppRequest<Guid>
    {
        public CreateIntervieweeDto CreateIntervieweeDto { get; set; }
    }
}
