using AutoMapper;
using Dapper;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Application.Shared.Responses;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Enums;
using EnhanceSure.Domain.Interfaces;
using EnhanceSure.Domain.Interfaces.Common;
using MediatR;

namespace EnhanceSure.Application.Features.Users.RegisterUsers.Commands {
    public class RegisterUserCommandHandler: RequestHandlerBase, IRequestHandler<RegisterUserCommand, AppResponse<Unit>> {
        private readonly IUserRepository _userRepository;
        private readonly IDbConnectionFactory _connection;
        private readonly IGenericRepositoryAsync<UserRole> _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public IUserRepository UserRepository { get; }
        public RegisterUserCommandHandler(IUserRepository userRepository, IDbConnectionFactory connection, IGenericRepositoryAsync<UserRole> userRoleRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository=userRepository;
            _connection=connection;
            _userRoleRepository=userRoleRepository;
            _mapper=mapper;
            _unitOfWork=unitOfWork;
        }
        public async Task<AppResponse<Unit>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            using var connection = _connection.CreateConnection();
            User requestedUser = await _userRepository.GetUserByEmailId(request.RegisterUserDto.Email!);

            if(requestedUser!=null) return Ok(Unit.Value, new string[] { "User already exists." });
            string returnMessage = _userRepository.CheckPasswordValidation(request.RegisterUserDto.Password);
            if(!string.IsNullOrEmpty(returnMessage)) return Ok(Unit.Value, new string[] { returnMessage });

            try
            {
                //Creating User
                var user = _mapper.Map<User>(request.RegisterUserDto);
                user.Password=_userRepository.EncryptPassword(request.RegisterUserDto.Password);
                user.Status=UserStatus.Active;
                await _userRepository.AddAsync(user);

                //Creating UserRole and assigning User as Default Role
                var query = $@"SELECT * FROM tbl_Roles WHERE RoleName= 'User'";
                var role = await connection.QueryFirstOrDefaultAsync<Role>(query);
                var userRole = new UserRole { UserId=user.Id, RoleId=role!.Id, };
                await _userRoleRepository.AddAsync(userRole);

                await _unitOfWork.Commit(cancellationToken);
            } catch(Exception exception)
            {
                if(exception.InnerException.Message.ToLower().Contains("primary_key violation"))
                {

                }

                throw exception;
            }

            return Ok(Unit.Value, new string[] { "You are registered successfully." });
        }
    }

}
