using EnhanceSure.Domain.Interfaces.Common;
using EnhanceSure.Persistance.DbContexts;

namespace EnhanceSure.Persistance.Repositories.Common {
    public class VirtualRepositoryAsync<T>: IVirtualRepositoryAsync<T> where T : class {
        private readonly ApplicationDbContext _dbContext;

        public VirtualRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public IQueryable<T> AsQueryable() => this.Entities.AsQueryable();
    }
}
