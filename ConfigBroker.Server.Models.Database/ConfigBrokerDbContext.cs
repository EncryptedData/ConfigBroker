using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConfigBroker.Server.Models.Database;

public class ConfigBrokerDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ConfigBrokerDbContext(DbContextOptions<ConfigBrokerDbContext> options) :
        base(options)
    {
    }
    
    public DbSet<Application> Applications { get; set; }
    
    public DbSet<ConfigItem> ConfigItems { get; set; }
    
    public DbSet<Snapshot> Snapshots { get; set; }
}