namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensorMonitoring.Domain.Model.Entities;

public class ReadingConfiguration : IEntityTypeConfiguration<Reading>
{
    public void Configure(EntityTypeBuilder<Reading> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.SensorId).IsRequired();
        builder.Property(r => r.Timestamp).IsRequired();
        builder.Property(r => r.Temperature).IsRequired();
        builder.Property(r => r.Humidity).IsRequired();
        builder.Property(r => r.Wind).IsRequired();
    }
}
