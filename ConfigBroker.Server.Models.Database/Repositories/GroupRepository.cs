using ConfigBroker.Server.Models.Database.Abstractions;
using ConfigBroker.Server.Models.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database.Repositories;

public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    public GroupRepository(ConfigBrokerDbContext context) : 
        base(context.Groups)
    {
    }

    public IAsyncEnumerable<Group> GetAsyncEnumerable(bool trackEntities = true)
    {
        return _db
            .SetTracking(trackEntities)
            .AsAsyncEnumerable();
    }
}