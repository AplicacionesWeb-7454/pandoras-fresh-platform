namespace PandorasFreshPlatform.API.SensorMonitoring.Infrastructure.Persistence.EFC.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SensorMonitoring.Domain.Model.Entities;


public class LinkConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.SensorId).IsRequired();
        builder.Property(l => l.Zone).IsRequired();
        builder.Property(l => l.Code).IsRequired();
        builder.Property(l => l.Notes).IsRequired();
    }
}
