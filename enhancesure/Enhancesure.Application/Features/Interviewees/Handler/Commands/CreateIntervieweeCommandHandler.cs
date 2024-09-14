using AutoMapper;
using BindraSawMill.Application.Shared.Responses;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Application.Features.Interviewees.Requests.Command;
using EnhanceSure.Domain.Entities;
using MediatR;

namespace EnhanceSure.Application.Features.Interviewees.Handler.Commands {
    public class CreateIntervieweeCommandHandler: RequestHandlerBase, IRequestHandler<CreateIntevieweeCommand, AppResponse<Guid>> {
        private readonly IIntervieweeRepository _interviewee;
        private readonly IMapper _mapper;
        public CreateIntervieweeCommandHandler(IMapper mapper, IIntervieweeRepository interviewee)
        {
            _mapper = mapper;
            _interviewee = interviewee;
        }

        public async Task<AppResponse<Guid>> Handle(CreateIntevieweeCommand request, CancellationToken cancellationToken)
        {
            var interviewee = _mapper.Map<Interviewee>(request);
            var response = await _interviewee.AddAsync(interviewee);
            return Ok(response.Id,new string[] { "Interviewee created successfully." });
        }
    }
}
