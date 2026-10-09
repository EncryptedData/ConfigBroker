namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface IConfigItemRepository : IRepository<ConfigItem>
{
    IAsyncEnumerable<ConfigItem> GetAsyncEnumerable(
        Application? application = null,
        Snapshot? snapshot = null,
        string? keyContains = null,
        string? valueContains = null,
        ConfigValueSource? sourceMatches = null,
        DateTime? lastModifiedStart = null,
        DateTime? lastModifiedEnd = null,
        IList<string>? containsLabels = null,
        IList<string>? containsTags = null,
        bool trackEntities = true);
}