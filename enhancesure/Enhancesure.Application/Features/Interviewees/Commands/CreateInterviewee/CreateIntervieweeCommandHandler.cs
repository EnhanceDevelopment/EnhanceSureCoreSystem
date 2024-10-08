using AutoMapper;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Application.Features.Interviewees.Commands.CreateInterviewee;
using EnhanceSure.Application.Shared.Responses;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Interfaces.Common;
using FluentValidation.Results;
using MediatR;
using System.Linq;

namespace EnhanceSure.Application.Features.Interviewees.Commands.CreateInterviewees
{
    public class CreateIntervieweeCommandHandler : RequestHandlerBase, IRequestHandler<CreateIntevieweeCommand, AppResponse<IntervieweeDto>>
    {
        private readonly IIntervieweeRepository _interviewee;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateIntervieweeCommandHandler(IMapper mapper, IIntervieweeRepository interviewee, IUnitOfWork unitOfWork)
        {
            _mapper=mapper;
            _interviewee=interviewee;
            _unitOfWork=unitOfWork;
        }

        public async Task<AppResponse<IntervieweeDto>> Handle(CreateIntevieweeCommand request, CancellationToken cancellationToken)
        {
            IntervieweeDto response=new IntervieweeDto();
            var validator = new CreateIntervieweeCommandValidator();
            var result= await validator.ValidateAsync(request, cancellationToken);
            if(!result.IsValid)
                return BadRequest<IntervieweeDto>(result.Errors.Select(i => i.ErrorMessage).ToArray<string>());
            var reqData = _mapper.Map<Interviewee>(request.CreateIntervieweeDto);
            var interviewee = await _interviewee.AddAsync(reqData);
            await _unitOfWork.Commit(cancellationToken);
            response = _mapper.Map<IntervieweeDto>(interviewee);
            return Ok(response, new string[] { "Interviewee created successfully." });
        }

        private AppResponse<T> BadRequest<T>(List<ValidationFailure> errors)
        {
            throw new NotImplementedException();
        }
    }
}
