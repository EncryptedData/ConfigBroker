using ConfigBroker.Server.Models.Database;
using ConfigBroker.Server.Models.Database.Config;
using Serilog;

namespace ConfigBroker.Server;

public class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        try
        {
            Log.Information("Loading ConfigBroker.Server...");
            
            var builder = WebApplication.CreateBuilder(args);
            
            ConfigureServices(builder.Services, builder.Configuration);
            
            var app = builder.Build();
            
            ConfigureApplication(app);
            
            Log.Information("Starting ConfigBroker.Server...");

            await app.RunAsync();
        }
        catch (Exception e)
        {
            Log.Error(e, "Unhandled exception killed ConfigBroker.Server Server");
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration config)
    {
        services.AddSerilog((sp, c) => c
            .ReadFrom.Configuration(config)
            .ReadFrom.Services(sp)
            .Enrich.FromLogContext()
            .WriteTo.Console());

        services.AddDbContext<ConfigBrokerDbContext>(options => 
            DatabaseConfiguration.Configure(options, config));
        services.AddDbContextFactory<ConfigBrokerDbContext>(options =>
            DatabaseConfiguration.Configure(options, config));
    }

    private static void ConfigureApplication(WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");
    }
}