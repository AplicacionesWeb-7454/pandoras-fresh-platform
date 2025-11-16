namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC;

using Microsoft.EntityFrameworkCore;
using SensorMonitoring.Domain.Model.Entities;


public class SensorMonitoringDbContext : DbContext
{
    public SensorMonitoringDbContext(DbContextOptions<SensorMonitoringDbContext> options)
        : base(options) { }

    public DbSet<Sensor> Sensors => Set<Sensor>();
    public DbSet<Reading> Readings => Set<Reading>();
    public DbSet<Zone> Zones => Set<Zone>();
    public DbSet<Status> Statuses => Set<Status>();
    public DbSet<Link> Links => Set<Link>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SensorMonitoringDbContext).Assembly);
    }
}
