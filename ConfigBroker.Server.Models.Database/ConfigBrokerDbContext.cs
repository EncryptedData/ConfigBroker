using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database;

public class ConfigBrokerDbContext : DbContext
{
    public ConfigBrokerDbContext(DbContextOptions<ConfigBrokerDbContext> options) :
        base(options)
    {
    }
}