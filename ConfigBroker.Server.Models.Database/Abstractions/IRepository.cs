namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface IRepository<T> 
    where T: IEntity
{
    Task<T?> GetByIdAsync(Guid id);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);
}