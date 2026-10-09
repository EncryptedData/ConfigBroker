using ConfigBroker.Server.Models.Database.Abstractions;
using ConfigBroker.Server.Models.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private ConfigBrokerDbContext _context;
    
    public UserRepository(ConfigBrokerDbContext context) : 
        base(context.Users)
    {
        _context = context;
    }

    public IAsyncEnumerable<User> GetAsyncEnumerable(string? likeName = null, bool trackEntities = true)
    {
        IQueryable<User> query = _db.SetTracking(trackEntities);

        if (!string.IsNullOrEmpty(likeName))
        {
            query = query.Where(e => EF.Functions.Like(e.Name, likeName));
        }

        return query.AsAsyncEnumerable();
    }

    public IAsyncEnumerable<User> GetUsersInGroup(Group group, bool trackEntities = true)
    {
        return _context.Set<UserGroupRoleClaim>()
            .SetTracking(trackEntities)
            .Where(e => e.Group.Id == group.Id)
            .Select(e => e.User)
            .Distinct()
            .ToAsyncEnumerable();
    }

    public IAsyncEnumerable<User> GetUsersInApplication(Application application, bool trackEntities = true)
    {
        return _context.Set<UserApplicationRoleClaim>()
            .SetTracking(trackEntities)
            .Where(e => e.Application.Id == application.Id)
            .Select(e => e.User)
            .Distinct()
            .ToAsyncEnumerable();
    }
}