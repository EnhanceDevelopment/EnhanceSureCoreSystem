using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Application.Features.Interviewees.Commands.CreateInterviewee;
using EnhanceSure.Application.Features.Interviewees.Queries.GetInterviewee;
using EnhanceSure.Application.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceSure.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class IntervieweeController: ControllerBase {

        private readonly IMediator _mediator;
        public IntervieweeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("createInterviewee")]
        public async Task<ActionResult<AppResponse<Guid>>> CreateIntervieweeAsync([FromBody] CreateIntervieweeDto interviewee,CancellationToken cancellationToken)
        {
            var command = new CreateIntevieweeCommand() { CreateIntervieweeDto = interviewee };
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
        [HttpGet("{intervieweeId}")]
        public async Task<ActionResult<AppResponse<Guid>>> GetIntervieweeAsync(Guid intervieweeId,CancellationToken cancellationToken)
        {
            var query = new GetIntervieweeQuery() { Id=intervieweeId};
            var response = await _mediator.Send(query,cancellationToken);
            return Ok(response);
        }        
    }
}
