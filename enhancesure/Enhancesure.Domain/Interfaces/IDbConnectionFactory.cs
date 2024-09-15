using System.Data;

namespace EnhanceSure.Domain.Interfaces {
    public interface IDbConnectionFactory: IDisposable {
        IDbConnection CreateConnection();
        Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }
}
