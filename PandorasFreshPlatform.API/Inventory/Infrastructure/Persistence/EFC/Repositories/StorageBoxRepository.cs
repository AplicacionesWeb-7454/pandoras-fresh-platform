using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PandorasFreshPlatform.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Represents the storage box repository in the Pandora's Fresh Platform.
/// </summary>
/// <param name="context">
/// The <see cref="AppDbContext" /> to use.
/// </param>
public class StorageBoxRepository(AppDbContext context) : BaseRepository<StorageBox>(context), IStorageBoxRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<StorageBox>> FindByInventoryIdAsync(InventoryItemId inventoryId)
    {
        return await Context.Set<StorageBox>()
            .Where(sb => sb.InventoryId.Equals(inventoryId))
            .ToListAsync()
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<StorageBox>> FindStorageBoxesWithCapacityAsync(InventoryItemId inventoryId, int requiredCapacity)
    {
        return await Context.Set<StorageBox>()
            .Where(sb => sb.InventoryId.Equals(inventoryId) && 
                        (sb.Capacity.Max - sb.Capacity.Current) >= requiredCapacity)
            .ToListAsync()
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<StorageBox?> GetStorageBoxWithContentAsync(StorageBoxId storageBoxId)
    {
        return await Context.Set<StorageBox>()
            .Include(sb => sb.ProductInstances)
                .ThenInclude(pi => pi.Product)
                    .ThenInclude(p => p.Category)
            .FirstOrDefaultAsync(sb => sb.Id.Equals(storageBoxId))
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsByLabelInInventoryAsync(string label, InventoryItemId inventoryId)
    {
        return await Context.Set<StorageBox>()
            .AnyAsync(sb => sb.Label == label && sb.InventoryId.Equals(inventoryId))
            .ConfigureAwait(false);
    }

    // Add method for the new Id type
    public async Task<StorageBox?> FindByIdAsync(StorageBoxId id)
    {
        return await Context.Set<StorageBox>()
            .Include(sb => sb.ProductInstances)
            .FirstOrDefaultAsync(sb => sb.Id.Equals(id))
            .ConfigureAwait(false);
    }
}