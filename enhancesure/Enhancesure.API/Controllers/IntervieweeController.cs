using BindraSawMill.Application.Shared.Responses;
using EnhanceSure.Application.DTOs.Interviewees;
using EnhanceSure.Application.Features.Interviewees.Requests.Command;
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
        public async Task<ActionResult<AppResponse<Guid>>> Post([FromBody] CreateIntervieweeDto interviewee)
        {
            var command = new CreateIntevieweeCommand() { CreateIntervieweeDto = interviewee };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
