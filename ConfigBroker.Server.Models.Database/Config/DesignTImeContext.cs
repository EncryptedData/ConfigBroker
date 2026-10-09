using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConfigBroker.Server.Models.Database.Config;

public class DesignTImeContext : IDesignTimeDbContextFactory<ConfigBrokerDbContext>
{
    public ConfigBrokerDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ConfigBrokerDbContext> builder = new();
        builder.UseNpgsql();

        return new ConfigBrokerDbContext(builder.Options);
    }
}