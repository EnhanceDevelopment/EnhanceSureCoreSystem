namespace EnhanceSure.Domain.Interfaces {
    public interface IVirtualRepositoryAsync<out T> where T : class {
        IQueryable<T> Entities { get; }
        IQueryable<T> AsQueryable();
    }
}
