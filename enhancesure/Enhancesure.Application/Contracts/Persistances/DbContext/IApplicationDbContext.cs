using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EnhanceSure.Application.Contracts.Persistances.DbContext {
    public interface IApplicationDbContext {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
    }
}
