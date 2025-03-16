using EnhanceSure.Domain.Common;

namespace EnhanceSure.Domain.Interfaces.Common {
    public interface IGenericRepositoryAsync<T>: IVirtualRepositoryAsync<T> where T : BaseEntity {
        Task<T> GetByIdAsync(Guid Id);
        Task<T> GetByIdAsNoTrackingAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllReadOnlyListAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> Exists(Guid id);
        Task DeleteAsync(T entity);

    }
}
