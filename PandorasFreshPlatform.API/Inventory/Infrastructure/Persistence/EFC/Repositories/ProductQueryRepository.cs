using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace PandorasFreshPlatform.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Represents the product query repository in the Pandora's Fresh Platform.
/// </summary>
/// <param name="context">
/// The <see cref="AppDbContext" /> to use.
/// </param>
public class ProductQueryRepository(AppDbContext context) : IProductQueryRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<Product>> GetProductTypesByInventoryAsync(InventoryItemId inventoryId)
    {
        // Get storage box IDs for the given inventory
        var storageBoxIds = await context.Set<StorageBox>()
            .Where(sb => sb.InventoryId == inventoryId.Id)
            .Select(sb => sb.Id)
            .ToListAsync();

        return await context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .Where(pi => pi.StorageBoxId.HasValue && storageBoxIds.Contains(pi.StorageBoxId.Value))
            .Select(pi => pi.Product)
            .Distinct()
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> GetProductTypesByStorageBoxAsync(StorageBoxId storageBoxId)
    {
        return await context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .Where(pi => pi.StorageBoxId.HasValue && pi.StorageBoxId.Value == storageBoxId.Id)
            .Select(pi => pi.Product)
            .Distinct()
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> GetFilteredProductInstancesAsync(CategoryId? categoryId, string? status, InventoryItemId? inventoryId, StorageBoxId? storageBoxId)
    {
        var query = context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .AsQueryable();

        if (categoryId is not null)
        {
            query = query.Where(pi => pi.Product.CategoryId == categoryId.Value);
        }

        if (!string.IsNullOrEmpty(status))
        {
            if (Enum.TryParse<EProductStatus>(status, out var statusEnum))
            {
                query = query.Where(pi => pi.Status == statusEnum);
            }
        }

        if (inventoryId is not null)
        {
            // Get storage box IDs for the given inventory
            var storageBoxIds = context.Set<StorageBox>()
                .Where(sb => sb.InventoryId == inventoryId.Id)
                .Select(sb => sb.Id);

            query = query.Where(pi => pi.StorageBoxId.HasValue && storageBoxIds.Contains(pi.StorageBoxId.Value));
        }

        if (storageBoxId is not null)
        {
            query = query.Where(pi => pi.StorageBoxId.HasValue && pi.StorageBoxId.Value == storageBoxId.Id);
        }

        return await query.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Product>> GetFilteredProductTypesAsync(CategoryId? categoryId, InventoryItemId? inventoryId)
    {
        var query = context.Set<Product>()
            .Include(p => p.Category)
            .AsQueryable();

        if (categoryId is not null)
        {
            query = query.Where(p => p.CategoryId == categoryId.Value);
        }

        if (inventoryId is not null)
        {
            // Get storage box IDs for the given inventory
            var storageBoxIds = context.Set<StorageBox>()
                .Where(sb => sb.InventoryId == inventoryId.Id)
                .Select(sb => sb.Id);

            // Get product instances in those storage boxes
            var productIdsInInventory = context.Set<ProductInstance>()
                .Where(pi => pi.StorageBoxId.HasValue && storageBoxIds.Contains(pi.StorageBoxId.Value))
                .Select(pi => pi.ProductId)
                .Distinct();

            query = query.Where(p => productIdsInInventory.Contains(p.Id));
        }

        return await query.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<object>> GetInventoryQuickViewAsync()
    {
        // Since InventoryItem uses InventoryItemId but StorageBox uses int for InventoryId,
        // we need to handle the conversion properly
        var inventoryItems = await context.Set<InventoryItem>().ToListAsync();
        var storageBoxes = await context.Set<StorageBox>().ToListAsync();
        var productInstances = await context.Set<ProductInstance>().ToListAsync();

        var result = inventoryItems.Select(i => new
        {
            InventoryId = i.Id,
            InventoryName = i.Name,
            TotalStorageBoxes = storageBoxes.Count(sb => sb.InventoryId == i.Id.Id),
            TotalProductInstances = productInstances.Count(pi => 
                pi.StorageBoxId.HasValue && 
                storageBoxes.Any(sb => sb.Id == pi.StorageBoxId.Value && sb.InventoryId == i.Id.Id)),
            ExpiringSoon = productInstances.Count(pi => 
                pi.StorageBoxId.HasValue && 
                storageBoxes.Any(sb => sb.Id == pi.StorageBoxId.Value && sb.InventoryId == i.Id.Id) &&
                pi.ExpirationDate.Date <= DateTime.UtcNow.AddDays(3) && 
                pi.ExpirationDate.Date > DateTime.UtcNow)
        });

        return result.ToList();
    }
}