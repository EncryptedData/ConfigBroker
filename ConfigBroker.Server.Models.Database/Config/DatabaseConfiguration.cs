using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConfigBroker.Server.Models.Database.Config;

public static class DatabaseConfiguration
{
    public static void Configure(DbContextOptionsBuilder options, IConfiguration config)
    {
        options.UseNpgsql(config.GetConnectionString("Database"));
    }
}