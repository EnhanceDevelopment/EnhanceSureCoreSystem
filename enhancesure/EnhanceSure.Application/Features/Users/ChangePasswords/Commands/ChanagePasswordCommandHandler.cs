using AutoMapper;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Application.DTOs.Users.ChangePasswords;
using EnhanceSure.Application.Shared.Responses;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Interfaces;
using EnhanceSure.Domain.Interfaces.Common;
using MediatR;

namespace EnhanceSure.Application.Features.Users.ChangePasswords.Commands {
    public class ChanagePasswordCommandHandler: RequestHandlerBase, IRequestHandler<ChangePasswordCommand, AppResponse<ChangePasswordResponseDto>> {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChanagePasswordCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository=userRepository;
            _mapper=mapper;
            _unitOfWork=unitOfWork;
        }

        public async Task<AppResponse<ChangePasswordResponseDto>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailId(request.ChangePasswordCommandDto.Email);
            var response = new ChangePasswordResponseDto();
            if(user==null)
                return BadRequest<ChangePasswordResponseDto>(new ChangePasswordResponseDto(), new string[] { "No user found with this email." });
            bool isOldPasswordMatch = _userRepository.CheckPassword(user.Password,request.ChangePasswordCommandDto.OldPassword);
            if(isOldPasswordMatch)
                return BadRequest<ChangePasswordResponseDto>(new ChangePasswordResponseDto(), new string[] { "Invalid Old Password." });
            string returnMessage = _userRepository.CheckPasswordValidation(request.ChangePasswordCommandDto.NewPassword);
            if(!string.IsNullOrEmpty(returnMessage)) 
                return Ok(new ChangePasswordResponseDto(), new string[] { returnMessage });

            user.Password=_userRepository.EncryptPassword(request.ChangePasswordCommandDto.NewPassword);
             await _userRepository.UpdateAsync(user);
            await _unitOfWork.Commit(cancellationToken);
            return Ok(response,new string[]{ "Password changed Successfully."});
        }
    }
}
