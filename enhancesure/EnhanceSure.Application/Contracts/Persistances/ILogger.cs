using EnhanceSure.Domain.Entities;
using EnhanceSure.Domain.Enum;
using EnhanceSure.Domain.Interfaces.Common;

namespace EnhanceSure.Application.Contracts.Persistances;
public interface ILogger: IGenericRepositoryAsync<ErrorLog> {
    void LogErrorAsync(Exception exception, CancellationToken cancellationToken, ErrorCategory? errorCategory);
}