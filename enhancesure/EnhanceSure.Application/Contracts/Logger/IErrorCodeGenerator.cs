using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Interfaces.Common;
using MediatR;

namespace EnhanceSure.Application.Contracts.Logger {
    public interface IErrorCodeGenerator {
        Task<string> GenerateNextErrorCode(string prefix);
    }
    public class CreateErrorLogCommand: IRequest {
        public string Prefix { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
    }

    // Application/ErrorLogs/Handlers/CreateErrorLogHandler.cs
    //public class CreateErrorLogHandler: IRequestHandler<CreateErrorLogCommand> {
    //    private readonly IErrorCodeGenerator _errorCodeGenerator;
    //    private readonly IUnitOfWork _unitOfWork;

    //    public CreateErrorLogHandler(IErrorCodeGenerator errorCodeGenerator, IUnitOfWork unitOfWork)
    //    {
    //        _errorCodeGenerator=errorCodeGenerator;
    //        _unitOfWork=unitOfWork;
    //    }

    //    public async Task<Unit> Handle(CreateErrorLogCommand request, CancellationToken cancellationToken)
    //    {
    //        var nextErrorCode = await _errorCodeGenerator.GenerateNextErrorCode(request.Prefix);

    //        var errorLog = new ErrorLog
    //        {
    //            ErrorCode=nextErrorCode,
    //            ErrorMessage=request.ErrorMessage,
    //            UserName=request.UserName,
    //            CreatedAtUtc=DateTime.UtcNow
    //        };

    //        _unitOfWork.Repository<ErrorLog>().Add(errorLog);
    //        await _unitOfWork.Commit(cancellationToken);

    //        return Unit.Value;
    //    }
    //}

}
