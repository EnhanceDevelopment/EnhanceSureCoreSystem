using EnhanceSure.Application.DTOs.Users.RegisterUsers;
using EnhanceSure.Application.DTOs.Users.UserLogins;
using EnhanceSure.Application.Features.Users.RegisterUsers.Commands;
using EnhanceSure.Application.Features.Users.UserLogins.Commands;
using EnhanceSure.Application.Shared.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnhanceSure.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost]
        [Route("userlogin")]
        public async Task<ActionResult<AppResponse<UserLoginResponseDto>>> UserLoginRequestAsync([FromBody] UserLoginCommandDto userLoginCommandDto,CancellationToken cancellationToken)
        {
            var command = new UserLoginCommand() { UserLoginCommandDto=userLoginCommandDto};
            var response = await _mediator.Send(command,cancellationToken);
            return Ok(response);
        }
        [HttpPost]
        [Route("registeruser")]

        public async Task<ActionResult<AppResponse<UserLoginResponseDto>>> RegisterUserAsync(RegisterUserDto registerUserDto, CancellationToken cancellationToken)
        {
            var command = new RegisterUserCommand() { RegisterUserDto=registerUserDto };
            var response = await _mediator.Send(command,cancellationToken);
            return Ok(response);
        }
    }
}
