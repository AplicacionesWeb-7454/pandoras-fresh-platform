using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates;

namespace PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        public DbSet<Report> Reports => Set<Report>();
        public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
        public DbSet<LossRecord> LossRecords => Set<LossRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(r => r.Title).HasMaxLength(100);
                entity.Property(r => r.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<LossRecord>(entity =>
            {
                entity.Property(l => l.Reason).HasMaxLength(250);
            });

          
        }
    }
}