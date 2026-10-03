using ConfigBroker.Server.Models.Database.Abstractions;

namespace ConfigBroker.Server.Models.Database.Repositories;

public abstract class BaseRepository<T> : 
    IRepository<T> where T: IEntity
{
    public Task<T?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}