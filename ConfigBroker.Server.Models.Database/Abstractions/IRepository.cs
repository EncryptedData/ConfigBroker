namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface IRepository<T> 
    where T: IEntity
{
    Task<T?> GetByIdAsync(Guid id, bool trackEntity = true);

    Task AddAsync(T entity);

    void Remove(T entity);

    Task RemoveById(Guid id);
}