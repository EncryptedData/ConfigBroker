namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface IGroupRepository : IRepository<Group>
{
    IAsyncEnumerable<Group> GetAsyncEnumerable(bool trackEntities = true);
}