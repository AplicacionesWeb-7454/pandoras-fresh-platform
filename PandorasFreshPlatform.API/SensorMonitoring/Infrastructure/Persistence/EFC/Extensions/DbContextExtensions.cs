namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DbContextExtensions
{
    public static IServiceCollection AddSensorMonitoringDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SensorMonitoringDbContext>(options =>
            options.UseMySQL(connectionString));

        return services;
    }
}
