using Application.Shared.Extensions;
using Dapper;
using EnhanceSure.Application.Contracts.Persistances;
using EnhanceSure.Domain.Constants;
using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Enum;
using EnhanceSure.Domain.Interfaces;
using EnhanceSure.Domain.Interfaces.Common;
using EnhanceSure.Persistance.DbContexts;
using EnhanceSure.Persistance.Repositories.Common;

namespace EnhanceSure.Persistance.Repositories {
    internal class Logger: GenericRepositoryAsync<ErrorLog>, ILogger {
        private readonly IDbConnectionFactory _connection;
        private readonly IUnitOfWork _unitOfWork;
        public Logger(IDbConnectionFactory connection, ApplicationDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext)
        {
            _connection=connection;
            _unitOfWork=unitOfWork;
        }
        public void LogErrorAsync(Exception exception, CancellationToken cancellationToken, ErrorCategory? errorCategory)
        {
            using var connection = _connection.CreateConnection();
            var query = $@"SELECT TOP 1 * FROM sys_ErrorLogs ORDER BY CAST(SUBSTRING(ErrorCode, 4, LEN(ErrorCode)) AS INT) DESC ";
            var errorLog = connection.QueryFirstOrDefault<ErrorLog>(query);
            long nextNumber = Convert.ToInt64(errorLog?.ErrorCode.Substring(3, errorLog.ErrorCode.Length))+1;
            var decoratedNumericValue = nextNumber.ToString().PadLeft(12, '0');
            var errorToLog = new ErrorLog();
            if(errorCategory!=null)
            {
                errorToLog=new ErrorLog
                {
                    ErrorCode=ErrorPrefix.CommonOrUnHandledErrors+decoratedNumericValue,
                    ErrorMessage=exception.Flatten(),
                };
            } else
            {
                switch(errorCategory!)
                {
                    case ErrorCategory.UNH:
                        errorToLog=new ErrorLog
                        {
                            ErrorCode=ErrorPrefix.CommonOrUnHandledErrors+decoratedNumericValue,
                            ErrorMessage=exception.Flatten(),
                        };
                        break;
                    case ErrorCategory.TRN:
                        errorToLog=new ErrorLog
                        {
                            ErrorCode=ErrorPrefix.TransactionError+decoratedNumericValue,
                            ErrorMessage=exception.Flatten(),
                        };
                        break;
                    case ErrorCategory.SYS:
                        errorToLog=new ErrorLog
                        {
                            ErrorCode=ErrorPrefix.SystemError+decoratedNumericValue,
                            ErrorMessage=exception.Flatten(),
                        };
                        break;
                }
            }
            this.AddAsync(errorToLog);
            _unitOfWork.Commit(cancellationToken);
        }
    }
}
