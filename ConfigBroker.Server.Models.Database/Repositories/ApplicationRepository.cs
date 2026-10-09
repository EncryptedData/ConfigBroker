using ConfigBroker.Server.Models.Database.Abstractions;
using ConfigBroker.Server.Models.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database.Repositories;

public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
{
    public ApplicationRepository(ConfigBrokerDbContext context) : 
        base(context.Applications)
    {
    }

    public async Task<Application?> GetApplicationByName(string name, bool trackEntities = true)
    {
        return await _db
            .SetTracking(trackEntities)
            .FirstOrDefaultAsync(e => e.Name == name);
    }

    public async Task<bool> HasApplicationByName(string name)
    {
        return await _db.AnyAsync(e => e.Name == name);
    }
}