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
        return await context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .Where(pi => pi.StorageBox != null && pi.StorageBox.InventoryId.Equals(inventoryId))
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
            .Where(pi => pi.StorageBoxId.HasValue && pi.StorageBoxId.Value.Equals(storageBoxId))
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
            .Include(pi => pi.StorageBox)
            .AsQueryable();

        if (categoryId is not null)
        {
            query = query.Where(pi => pi.Product.CategoryId.Equals(categoryId));
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
            query = query.Where(pi => pi.StorageBox != null && pi.StorageBox.InventoryId.Equals(inventoryId));
        }

        if (storageBoxId is not null)
        {
            query = query.Where(pi => pi.StorageBoxId.HasValue && pi.StorageBoxId.Value.Equals(storageBoxId));
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
            query = query.Where(p => p.CategoryId.Equals(categoryId));
        }

        if (inventoryId is not null)
        {
            var productIdsInInventory = context.Set<ProductInstance>()
                .Where(pi => pi.StorageBox != null && pi.StorageBox.InventoryId.Equals(inventoryId))
                .Select(pi => pi.ProductId)
                .Distinct();

            query = query.Where(p => productIdsInInventory.Contains(p.Id));
        }

        return await query.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<object>> GetInventoryQuickViewAsync()
    {
        return await context.Set<InventoryItem>()
            .Select(i => new
            {
                InventoryId = i.Id,
                InventoryName = i.Name,
                TotalStorageBoxes = i.StorageBoxes.Count,
                TotalProductInstances = i.StorageBoxes.Sum(sb => sb.ProductInstances.Count),
                ExpiringSoon = i.StorageBoxes
                    .SelectMany(sb => sb.ProductInstances)
                    .Count(pi => pi.ExpirationDate.Date <= DateTime.UtcNow.AddDays(3) && 
                                pi.ExpirationDate.Date > DateTime.UtcNow)
            })
            .ToListAsync();
    }
}