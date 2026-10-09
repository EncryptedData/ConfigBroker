using ConfigBroker.Server.Models.Database.Abstractions;
using ConfigBroker.Server.Models.Database.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

namespace ConfigBroker.Server.Models.Database.Repositories;

public class SnapshotRepository : BaseRepository<Snapshot>, ISnapshotRepository
{
    public SnapshotRepository(ConfigBrokerDbContext context) : 
        base(context.Snapshots)
    {
    }

    public IAsyncEnumerable<Snapshot> GetAsyncEnumerable(
        string? likeName = null, 
        User? createdBy = null, 
        DateTime? createdBefore = null,
        DateTime? createdAfter = null, 
        Application? application = null, 
        bool trackEntities = true)
    {
        IQueryable<Snapshot> query = _db.SetTracking(trackEntities);
        
        if (!string.IsNullOrEmpty(likeName))
        {
            query = query.Where(e => 
                EF.Functions.Like(e.Name, likeName));
        }

        if (createdBy is not null)
        {
            query = query.Where(e => e.CreatedBy.Id == createdBy.Id);
        }

        if (createdBefore is not null)
        {
            query = query.Where(e => e.CreatedOn <= createdBefore);
        }

        if (createdAfter is not null)
        {
            query = query.Where(e => e.CreatedOn >= createdAfter);
        }

        if (application is not null)
        {
            query = query.Where(e => e.Application.Id == application.Id);
        }

        return query.AsAsyncEnumerable();
    }
}