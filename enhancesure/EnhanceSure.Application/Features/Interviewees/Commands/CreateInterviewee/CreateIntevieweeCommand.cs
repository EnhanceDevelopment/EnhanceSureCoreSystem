using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Application.DTOs.Interviewers;
using EnhanceSure.Application.Shared.Request;
using EnhanceSure.Domain.Entities;
using MediatR;

namespace EnhanceSure.Application.Features.Interviewees.Commands.CreateInterviewee
{
    public class CreateIntevieweeCommand : AppRequest<IntervieweeDto>
    {
        public CreateIntervieweeDto CreateIntervieweeDto { get; set; }
    }
}
