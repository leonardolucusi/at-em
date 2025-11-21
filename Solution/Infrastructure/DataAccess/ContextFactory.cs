using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataAccess;

public class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var configuration = GetConfiguration();
        var connectionString = GetConnectionString(configuration);
        
        var builder = new DbContextOptionsBuilder<Context>();
        builder.UseNpgsql(connectionString);
#if DEBUG
        builder.EnableDetailedErrors();
        builder.EnableSensitiveDataLogging();      
#endif
        
        return new Context(builder.Options);
    }
    
    private static IConfigurationRoot GetConfiguration() =>
        new ConfigurationBuilder()
            .SetBasePath(@$"{Directory.GetParent(Directory.GetCurrentDirectory())}\1. Presentation")
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    
    public static IConfigurationRoot GetConfiguration(string directory) => 
        new ConfigurationBuilder()
            .SetBasePath(directory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
    
    public static string GetConnectionString(IConfigurationRoot configuration) =>
        configuration.GetConnectionString(nameof(Context)) ?? throw new InvalidOperationException("Connection string 'Context' not found.");
}