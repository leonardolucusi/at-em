using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Extensions;

internal static class DatabaseExtension
{
    internal static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        services.AddDbContext<Context>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Context"));

#if DEBUG
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
#endif
        });

        return services;
    }
}