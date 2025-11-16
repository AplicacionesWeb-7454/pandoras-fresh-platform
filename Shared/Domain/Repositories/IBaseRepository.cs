namespace pandoraFr.API.Shared.Domain.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> ListAsync();
    Task<T?> FindByIdAsync(Guid id);
    Task AddAsync(T entity);
    void Remove(T entity);
}