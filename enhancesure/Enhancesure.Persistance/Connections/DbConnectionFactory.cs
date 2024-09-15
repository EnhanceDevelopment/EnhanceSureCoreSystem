using Dapper;
using EnhanceSure.Domain.Interfaces;
using EnhanceSure.Persistance.Constants;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EnhanceSure.Persistance.Connections {
    public class DbConnectionFactory:IDbConnectionFactory  {
        private readonly IDbConnection _connection;
        private readonly string _connectionString;
        public DbConnectionFactory(IConfiguration configuration)
        {
            try
            {
                _connectionString=configuration.GetConnectionString(DbConnectionConstants.ConnectionStringName)??string.Empty;
                _connection=new SqlConnection(_connectionString);
            } catch(Exception ex)
            {

                throw new Exception($"Unable to connect to database. Please, contact your administrator.\n Error: {ex.Message}");
            }
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
