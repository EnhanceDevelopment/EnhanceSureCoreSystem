using Dapper;
using Domain.Interfaces;
using EnhanceSure.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace EnhanceSure.Persistance.Connections {
    public class ApplicationReadDbConnection : IApplicationReadDbConnection {
        private readonly IDbConnection connection;
        public ApplicationReadDbConnection(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction);
        }
        public IDbConnection CreateConnection()
        {
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            return connection;
        }
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
