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
        IEnumerable<string>? containsLabels = null,
        IEnumerable<string>? containsTags = null,
        bool trackEntities = true);
}