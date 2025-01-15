using EnhanceSure.Application.Contracts.Infrastructure.Authentication;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Application.DTOs.Users.UserLogins;
using EnhanceSure.Application.Shared.Responses;
using EnhanceSure.Domain.Errors;
using EnhanceSure.Domain.Interfaces;
using MediatR;

namespace EnhanceSure.Application.Features.Users.UserLogins.Commands {
    public class UserLoginCommandHandler: RequestHandlerBase, IRequestHandler<UserLoginCommand, AppResponse<UserLoginResponseDto>> {
        private readonly IDbConnectionFactory _connection;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        public IUserRepository UserRepository { get; }
        public UserLoginCommandHandler(IDbConnectionFactory connection, IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _connection=connection;
            _userRepository=userRepository;
            _jwtProvider=jwtProvider;
        }
        public async Task<AppResponse<UserLoginResponseDto>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            using var connection = _connection.CreateConnection();
            var user = await _userRepository.GetUserByEmailId(request.UserLoginCommandDto!.Email);
            if(user==null) return NotFound<UserLoginResponseDto>(new UserLoginResponseDto(), new string[] { DomainErrors.User.UserNotFound });
            var checkPassword = _userRepository.CheckPassword(user.Password,request.UserLoginCommandDto.Password);
            if(checkPassword)
                return Ok(new UserLoginResponseDto { Token=_jwtProvider.GenerateToken(user) }, new string[] { DomainErrors.User.LoggedInSucceed });
            else
                return Ok(new UserLoginResponseDto { Token=null},new string[] {DomainErrors.User.InvalidCredentials });
        }
    }
}
