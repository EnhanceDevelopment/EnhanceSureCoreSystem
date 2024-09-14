using Dapper;
using Domain.Interfaces;
using EnhanceSure.Persistance.Constants;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EnhanceSure.Persistance.Connections {
    public class DbConnectionFactory:IDbConnectionFactory,IDisposable  {
        private readonly IDbConnection _connection;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _connection = new SqlConnection(configuration.GetConnectionString(DbConnectionConstants.ConnectionStringName));
        }
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await _connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await _connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await _connection.QuerySingleAsync<T>(sql, param, transaction);
        }
        public IDbConnection CreateConnection()
        {
            if(_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }
        public void Dispose()
        {
            _connection.Dispose();
        }

    }
}
