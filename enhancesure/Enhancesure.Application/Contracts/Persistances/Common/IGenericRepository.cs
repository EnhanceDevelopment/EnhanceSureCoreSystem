namespace EnhanceSure.Application.Contracts.Persistances.Common
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
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
