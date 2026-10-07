namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface ISnapshotRepository : IRepository<Snapshot>
{
    IAsyncEnumerable<Snapshot> GetAsyncEnumerable(
        string? likeName = null,
        User? createdBy = null,
        DateTime? createdBefore = null,
        DateTime? createdAfter = null,
        Application? application = null,
        bool trackEntities = true);
}