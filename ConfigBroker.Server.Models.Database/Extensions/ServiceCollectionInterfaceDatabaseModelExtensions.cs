using ConfigBroker.Server.Models.Database.Abstractions;
using ConfigBroker.Server.Models.Database.Config;
using ConfigBroker.Server.Models.Database.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigBroker.Server.Models.Database.Extensions;

public static class ServiceCollectionInterfaceDatabaseModelExtensions
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ConfigBrokerDbContext>(options => 
            DatabaseConfiguration.Configure(options, config));
        services.AddDbContextFactory<ConfigBrokerDbContext>(options =>
            DatabaseConfiguration.Configure(options, config));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}