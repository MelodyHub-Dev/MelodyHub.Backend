using MelodyHub.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MelodyHub.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        var serverVersion = new MySqlServerVersion(new Version(configuration["DatabaseSettings:ServerVersion"]
            ?? throw new NullReferenceException("server version was null")));

        services.AddDbContext<MelodyHubDbContext>(options =>
        {
            options.UseMySql(
                connectionString,
                serverVersion,
                mySqlOptions => mySqlOptions.EnableStringComparisonTranslations()
            );
        });

        services.AddScoped<IMelodyHubDbContext>(provider =>
            provider.GetService<MelodyHubDbContext>()
                ?? throw new NullReferenceException("provider cant't be null"));

        return services;
    }
}