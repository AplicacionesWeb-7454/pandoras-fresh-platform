using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace PandorasFreshPlatform.API.Inventory.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyInventoryConfiguration(this ModelBuilder builder)
    {
        ApplyProductConfiguration(builder);
        ApplyInventoryItemConfiguration(builder);
        ApplyStorageBoxConfiguration(builder);
        ApplyProductInstanceConfiguration(builder);
    }

    private static void ApplyProductConfiguration(ModelBuilder builder)
    {
        // Product Aggregate
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(500);

        // Category Entity
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);

        // Product-Category Relationship
        builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Barcode Value Object (Owned Type)
        builder.Entity<Product>().OwnsOne(p => p.Barcode, b =>
        {
            b.Property(p => p.Code).HasColumnName("Barcode").HasMaxLength(100);
        });

        // Indexes for performance
        builder.Entity<Product>().HasIndex(p => p.Name);
        builder.Entity<Product>().HasIndex(p => new { p.Name, p.CategoryId });
    }

    private static void ApplyInventoryItemConfiguration(ModelBuilder builder)
    {
        // InventoryItem Aggregate
        builder.Entity<InventoryItem>().HasKey(i => i.Id);
        
        // Configure InventoryItemId value object conversion - FIXED
        builder.Entity<InventoryItem>()
            .Property(i => i.Id)
            .HasConversion(
                id => id.Id,  // Use .Id instead of .Value
                value => new InventoryItemId(value))
            .IsRequired()
            .ValueGeneratedOnAdd();
            
        builder.Entity<InventoryItem>().Property(i => i.Name).IsRequired().HasMaxLength(100);
        builder.Entity<InventoryItem>().Property(i => i.Description).IsRequired().HasMaxLength(500);

        // Location Value Object (Owned Type)
        builder.Entity<InventoryItem>().OwnsOne(i => i.Location, l =>
        {
            l.Property(loc => loc.Value).HasColumnName("Location").HasMaxLength(200); // Fixed parameter name
        });

        // InventoryItem-StorageBox Relationship
        builder.Entity<InventoryItem>()
            .HasMany(i => i.StorageBoxes)
            .WithOne(sb => sb.Inventory)
            .HasForeignKey(sb => sb.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes for performance
        builder.Entity<InventoryItem>().HasIndex(i => i.Name);
    }

    private static void ApplyStorageBoxConfiguration(ModelBuilder builder)
    {
        // StorageBox Entity
        builder.Entity<StorageBox>().HasKey(sb => sb.Id);
        builder.Entity<StorageBox>().Property(sb => sb.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<StorageBox>().Property(sb => sb.Label).IsRequired().HasMaxLength(50);

        // Capacity Value Object (Owned Type)
        builder.Entity<StorageBox>().OwnsOne(sb => sb.Capacity, c =>
        {
            c.Property(cap => cap.Max).HasColumnName("MaxCapacity");
            c.Property(cap => cap.Current).HasColumnName("CurrentCapacity");
        });

        // StorageConditions Value Object (Owned Type)
        builder.Entity<StorageBox>().OwnsOne(sb => sb.StorageConditions, sc =>
        {
            sc.Property(cond => cond.TemperatureRange).HasColumnName("TemperatureRange").HasMaxLength(50);
        });

        // StorageBoxIdentifier Value Object (Owned Type)
        builder.Entity<StorageBox>().OwnsOne(sb => sb.BoxIdentifier, bi =>
        {
            bi.Property(boxId => boxId.Identifier).HasColumnName("StorageBoxIdentifier");
        });

        // StorageBox-ProductInstance Relationship
        builder.Entity<StorageBox>()
            .HasMany(sb => sb.ProductInstances)
            .WithOne(pi => pi.StorageBox)
            .HasForeignKey(pi => pi.StorageBoxId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes for performance
        builder.Entity<StorageBox>().HasIndex(sb => sb.Label);
        builder.Entity<StorageBox>().HasIndex(sb => new { sb.Label, sb.InventoryId });
    }

    private static void ApplyProductInstanceConfiguration(ModelBuilder builder)
    {
        // ProductInstance Entity
        builder.Entity<ProductInstance>().HasKey(pi => pi.Id);
        builder.Entity<ProductInstance>().Property(pi => pi.Id).IsRequired().ValueGeneratedOnAdd();

        // ProductInstanceIdentifier Value Object (Owned Type)
        builder.Entity<ProductInstance>().OwnsOne(pi => pi.InstanceIdentifier, ii =>
        {
            ii.Property(instId => instId.Identifier).HasColumnName("ProductInstanceIdentifier");
        });

        // ExpirationDate Value Object (Owned Type)
        builder.Entity<ProductInstance>().OwnsOne(pi => pi.ExpirationDate, ed =>
        {
            ed.Property(exp => exp.Date).HasColumnName("ExpirationDate");
        });

        // EntryDate Value Object (Owned Type)
        builder.Entity<ProductInstance>().OwnsOne(pi => pi.EntryDate, ed =>
        {
            ed.Property(entry => entry.Date).HasColumnName("EntryDate");
        });

        // Batch Value Object (Owned Type)
        builder.Entity<ProductInstance>().OwnsOne(pi => pi.Batch, b =>
        {
            b.Property(batch => batch.Number).HasColumnName("BatchNumber").HasMaxLength(50);
        });

        // ProductInstance-Product Relationship
        builder.Entity<ProductInstance>()
            .HasOne(pi => pi.Product)
            .WithMany()
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // Status configuration
        builder.Entity<ProductInstance>()
            .Property(pi => pi.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        // Indexes for performance
        builder.Entity<ProductInstance>().HasIndex(pi => pi.ProductId);
        builder.Entity<ProductInstance>().HasIndex(pi => pi.StorageBoxId);
    }
}