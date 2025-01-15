using AutoMapper;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Application.DTOs.Users.RegisterUsers;
using EnhanceSure.Application.Shared.Responses;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Enums;
using EnhanceSure.Domain.Interfaces.Common;
using MediatR;

namespace EnhanceSure.Application.Features.Users.RegisterUsers.Commands {
    public class RegisterUserCommandHandler: RequestHandlerBase, IRequestHandler<RegisterUserCommand, AppResponse<Unit>> {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public IUserRepository UserRepository { get; }
        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository=userRepository;
            _mapper=mapper;
            _unitOfWork=unitOfWork;
        }
        public async Task<AppResponse<Unit>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult= new RegisterUserCommandValidator().ValidateAsync(new RegisterUserDto());
            if(!validationResult.IsCompletedSuccessfully) return Ok(Unit.Value,new string[] {validationResult?.Exception.Message});
            User requestedUser = await _userRepository.GetUserByEmailId(request.RegisterUserDto.Email!);

            if(requestedUser!=null) return Ok(Unit.Value, new string[] { "User already exists." });
            string returnMessage =  _userRepository.CheckPasswordValidation(request.RegisterUserDto.Password);
            if(!string.IsNullOrEmpty(returnMessage)) return Ok(Unit.Value, new string[] { returnMessage });

            var user = _mapper.Map<User>(requestedUser);
            user.Password=_userRepository.EncryptPassword(request.RegisterUserDto.Password);
            user.Status=UserStatus.Active;

            await _userRepository.AddAsync(user);
            await _unitOfWork.Commit(cancellationToken);

            return Ok(Unit.Value, new string[] { "You are registered successfully." });
        }
    }

}
