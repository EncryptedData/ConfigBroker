using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConfigBroker.Server.Models.Database.Config;

public class ConfigBrokerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ConfigBrokerDbContext>
{
    public ConfigBrokerDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ConfigBrokerDbContext> builder = new();
        builder.UseNpgsql();

        return new ConfigBrokerDbContext(builder.Options);
    }
}