using System.Data;

namespace Domain.Interfaces {
    public interface IDbConnectionFactory : IDisposable {
        IDbConnection CreateConnection();
    }
}
