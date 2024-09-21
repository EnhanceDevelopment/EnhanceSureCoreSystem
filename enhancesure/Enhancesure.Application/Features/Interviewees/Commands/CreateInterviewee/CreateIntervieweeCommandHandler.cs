using AutoMapper;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Application.Features.Interviewees.Commands.CreateInterviewee;
using EnhanceSure.Application.Shared.Responses;
using EnhanceSure.Domain.Entities;
using MediatR;

namespace EnhanceSure.Application.Features.Interviewees.Commands.CreateInterviewees
{
    public class CreateIntervieweeCommandHandler : RequestHandlerBase, IRequestHandler<CreateIntevieweeCommand, AppResponse<IntervieweeDto>>
    {
        private readonly IIntervieweeRepository _interviewee;
        private readonly IMapper _mapper;
        public CreateIntervieweeCommandHandler(IMapper mapper, IIntervieweeRepository interviewee)
        {
            _mapper = mapper;
            _interviewee = interviewee;
        }

        public async Task<AppResponse<IntervieweeDto>> Handle(CreateIntevieweeCommand request, CancellationToken cancellationToken)
        {
            var reqData = _mapper.Map<Interviewee>(request.CreateIntervieweeDto);
            var interviewee = await _interviewee.AddAsync(reqData);
            var response = _mapper.Map<IntervieweeDto>(interviewee);
            return Ok(response, new string[] { "Interviewee created successfully." });
        }
    }
}
