using ConfigBroker.Server.Models.Database.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database.Repositories;

public abstract class BaseRepository<T> : 
    IRepository<T> where T: class, IEntity
{
    protected DbSet<T> _db;
    
    protected BaseRepository(DbSet<T> db)
    {
        _db = db;
    }
    
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _db.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        await _db.AddAsync(entity);
    }

    public void Remove(T entity)
    {
        _db.Remove(entity);
    }

    public async Task RemoveById(Guid id)
    {
        T? entity = await GetByIdAsync(id);

        if (entity is not null)
        {
            Remove(entity);
        }
    }
}