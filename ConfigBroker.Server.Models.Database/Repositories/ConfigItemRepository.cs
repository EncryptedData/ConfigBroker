using ConfigBroker.Server.Models.Database.Abstractions;
using ConfigBroker.Server.Models.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database.Repositories;

public class ConfigItemRepository : BaseRepository<ConfigItem>, IConfigItemRepository
{
    public ConfigItemRepository(ConfigBrokerDbContext context) : 
        base(context.ConfigItems)
    {
    }

    public IAsyncEnumerable<ConfigItem> GetAsyncEnumerable(
        Application? application = null, 
        Snapshot? snapshot = null,
        string? keyContains = null, 
        string? valueContains = null, 
        ConfigValueSource? sourceMatches = null,
        DateTime? lastModifiedStart = null, 
        DateTime? lastModifiedEnd = null, 
        IList<string>? containsLabels = null,
        IList<string>? containsTags = null, 
        bool trackEntities = true)
    {
        IQueryable<ConfigItem> query = _db.AsQueryable()
            .SetTracking(trackEntities);

        if (application is not null)
        {
            query = query.Where(e => e.Application.Id == application.Id);
        }

        if (snapshot is not null)
        {
            query = query.Where(e => e.Snapshot!.Id == snapshot.Id);
        }

        if (!string.IsNullOrEmpty(keyContains))
        {
            query = query.Where(e => e.Key.Contains(keyContains));
        }

        if (!string.IsNullOrEmpty(valueContains))
        {
            query = query.Where(e => e.Value.Contains(valueContains));
        }

        if (sourceMatches is not null)
        {
            query = query.Where(e => e.Source == sourceMatches);
        }

        if (lastModifiedStart is not null)
        {
            query = query.Where(e => e.LastModifiedOn >= lastModifiedStart);
        }

        if (lastModifiedEnd is not null)
        {
            query = query.Where(e => e.LastModifiedOn <= lastModifiedEnd);
        }

        if (containsLabels is not null && containsLabels.Any())
        {
            query = query.Where(e => e.Labels.Intersect(containsLabels).Any());
        }

        if (containsTags is not null && containsTags.Any())
        {
            query = query.Where(e => e.Tags.Intersect(containsTags).Any());
        }

        return query.AsAsyncEnumerable();
    }
}