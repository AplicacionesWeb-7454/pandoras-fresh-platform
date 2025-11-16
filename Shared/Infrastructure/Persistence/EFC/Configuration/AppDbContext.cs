using Microsoft.EntityFrameworkCore;
using pandoraFr.API.Reports.Infrastructure.Persistence.EFC.Entities;

namespace pandoraFr.API.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReportEntity> Reports => Set<ReportEntity>();
        public DbSet<InventoryItemEntity> InventoryItems => Set<InventoryItemEntity>();
        public DbSet<LossRecordEntity> LossRecords => Set<LossRecordEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔧 Convención global: todas las propiedades string serán varchar(255)
            foreach (var property in modelBuilder.Model
                         .GetEntityTypes()
                         .SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(255)");
            }

            // 📦 Configuración específica para decimales
            modelBuilder.Entity<InventoryItemEntity>(entity =>
            {
                entity.Property(e => e.Cost).HasPrecision(18, 2);
            });

            modelBuilder.Entity<LossRecordEntity>(entity =>
            {
                entity.Property(e => e.Cost).HasPrecision(18, 2);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}