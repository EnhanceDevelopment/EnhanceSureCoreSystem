using EnhanceSure.Domain.Common;
using EnhanceSure.Domain.Interfaces.Common;

namespace EnhanceSure.Domain.Interfaces
{
    public interface IRepositoryAsync<T>: IVirtualRepositoryAsync<T> where T : BaseEntity {
        Task<T> GetByIdAsync(Guid id);

        Task<T> GetByGuIdAsync(Guid id);

        Task<T> GetByIdAsNoTrackingAsync(Guid id);

        Task<List<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllReadOnlyListAsync();

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> Exists(Guid id);
    }
}
