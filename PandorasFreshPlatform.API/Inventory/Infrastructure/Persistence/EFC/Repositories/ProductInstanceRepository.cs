using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PandorasFreshPlatform.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Represents the product instance repository in the Pandora's Fresh Platform.
/// </summary>
/// <param name="context">
/// The <see cref="AppDbContext" /> to use.
/// </param>
public class ProductInstanceRepository(AppDbContext context) : BaseRepository<ProductInstance>(context), IProductInstanceRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> FindByStorageBoxIdAsync(StorageBoxId storageBoxId)
    {
        return await Context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .Where(pi => pi.StorageBoxId.HasValue && pi.StorageBoxId.Value == storageBoxId.Id)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> FindByInventoryIdAsync(InventoryItemId inventoryId)
    {
        // Since ProductInstance doesn't have a direct navigation to StorageBox,
        // we need to query StorageBox first and then get related ProductInstances
        var storageBoxIds = await Context.Set<StorageBox>()
            .Where(sb => sb.InventoryId == inventoryId.Id)
            .Select(sb => sb.Id)
            .ToListAsync();

        return await Context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .Where(pi => pi.StorageBoxId.HasValue && storageBoxIds.Contains(pi.StorageBoxId.Value))
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> FindExpiringProductsAsync(DateTime threshold)
    {
        return await Context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .Where(pi => pi.ExpirationDate.Date <= threshold.Date)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> FindByProductIdAsync(ProductId productId)
    {
        return await Context.Set<ProductInstance>()
            .Where(pi => pi.ProductId == productId.Value)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> GetProductInstancesWithDetailsAsync()
    {
        return await Context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<ProductInstance>> FindByStatusAsync(EProductStatus status)
    {
        return await Context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .Where(pi => pi.Status == status)
            .ToListAsync();
    }

    // Add method for the new Id type
    public async Task<ProductInstance?> FindByIdAsync(ProductInstanceId id)
    {
        return await Context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .FirstOrDefaultAsync(pi => pi.Id == id.Id);
    }

    /// <inheritdoc />
    public new async Task<IEnumerable<ProductInstance>> ListAsync()
    {
        return await Context.Set<ProductInstance>()
            .Include(pi => pi.Product)
                .ThenInclude(p => p.Category)
            .ToListAsync();
    }
}