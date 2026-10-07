namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface IUserRepository : IRepository<User>
{
    IAsyncEnumerable<User> GetAsyncEnumerable(
        string? likeName = null,
        bool trackEntities = true);

    IAsyncEnumerable<User> GetUsersInGroup(Group group, bool trackEntities = true);

    IAsyncEnumerable<User> GetUsersInApplication(Application application, bool trackEntities = true);
}