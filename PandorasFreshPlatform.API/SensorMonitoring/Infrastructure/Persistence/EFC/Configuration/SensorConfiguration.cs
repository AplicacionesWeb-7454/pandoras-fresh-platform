namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensorMonitoring.Domain.Model.Entities;


public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired();
        builder.Property(s => s.Zone).IsRequired();
        builder.Property(s => s.Location).IsRequired();
        builder.Property(s => s.Status).IsRequired();
        builder.Property(s => s.LastReading).IsRequired();
    }
}
