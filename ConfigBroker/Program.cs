using Serilog;

namespace ConfigBroker;

public class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        try
        {
            Log.Information("Loading ConfigBroker...");
            
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddSerilog((sp, c) => c
                .ReadFrom.Configuration(builder.Configuration)
                .ReadFrom.Services(sp)
                .Enrich.FromLogContext()
                .WriteTo.Console());
            
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            
            Log.Information("Starting ConfigBroker...");

            await app.RunAsync();
        }
        catch (Exception e)
        {
            Log.Error(e, "Unhandled exception killed ConfigBroker Server");
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}