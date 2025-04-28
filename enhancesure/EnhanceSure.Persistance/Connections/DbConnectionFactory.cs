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
        public IDbConnection CreateConnection()
        {
            if(_connection.State!=ConnectionState.Open)
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
