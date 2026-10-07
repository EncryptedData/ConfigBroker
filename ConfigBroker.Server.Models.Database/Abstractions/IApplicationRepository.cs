namespace ConfigBroker.Server.Models.Database.Abstractions;

public interface IApplicationRepository : IRepository<Application>
{
    Task<Application?> GetApplicationByName(string name, bool trackEntities = true);

    Task<bool> HasApplicationByName(string name);
}