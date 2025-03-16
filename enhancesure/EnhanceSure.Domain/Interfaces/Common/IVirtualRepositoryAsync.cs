namespace EnhanceSure.Domain.Interfaces.Common
{
    public interface IVirtualRepositoryAsync<out T> where T : class
    {
        IQueryable<T> Entities { get; }
        IQueryable<T> AsQueryable();
    }
}
