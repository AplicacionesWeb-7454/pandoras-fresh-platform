namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensorMonitoring.Domain.Model.Entities;


public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
{
    public void Configure(EntityTypeBuilder<Zone> builder)
    {
        builder.HasKey(z => z.Id);
        builder.Property(z => z.Name).IsRequired();
    }
}
