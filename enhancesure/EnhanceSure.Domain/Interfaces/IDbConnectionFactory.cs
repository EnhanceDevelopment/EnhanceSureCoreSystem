using System.Data;

namespace EnhanceSure.Domain.Interfaces {
    public interface IDbConnectionFactory: IDisposable {
        IDbConnection CreateConnection();
    }
}
