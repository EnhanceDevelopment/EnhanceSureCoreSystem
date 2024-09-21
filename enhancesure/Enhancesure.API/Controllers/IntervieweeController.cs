using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Application.Features.Interviewees.Commands.CreateInterviewee;
using EnhanceSure.Application.Features.Interviewees.Queries.GetInterviewee;
using EnhanceSure.Application.Shared.Responses;
using MediatR;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppResponse<Guid>>> CreateIntervieweeAsync([FromBody] CreateIntervieweeDto interviewee)
        {
            var command = new CreateIntevieweeCommand() { CreateIntervieweeDto = interviewee };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpGet("{intervieweeId}")]
        public async Task<ActionResult<AppResponse<Guid>>> GetIntervieweeAsync(Guid intervieweeId)
        {
            var query = new GetIntervieweeQuery() { Id=intervieweeId};
            var response = await _mediator.Send(query);
            return Ok(response);
        }        
    }
}
