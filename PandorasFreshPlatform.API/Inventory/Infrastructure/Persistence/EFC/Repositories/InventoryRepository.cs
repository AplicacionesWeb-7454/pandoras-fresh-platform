using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PandorasFreshPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace PandorasFreshPlatform.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Represents the inventory repository in the Pandora's Fresh Platform.
/// </summary>
/// <param name="context">
/// The <see cref="AppDbContext" /> to use.
/// </param>
public class InventoryRepository(AppDbContext context) : BaseRepository<InventoryItem>(context), IInventoryRepository
{
    /// <inheritdoc />
    public async Task<InventoryItem?> FindByNameAsync(string name)
    {
        return await Context.Set<InventoryItem>()
            .FirstOrDefaultAsync(i => i.Name == name);
    }

    /// <inheritdoc />
    public async Task<InventoryItem?> GetWithStorageBoxesAsync(InventoryItemId id)
    {
        return await Context.Set<InventoryItem>()
            .Include(i => i.StorageBoxes)
            .FirstOrDefaultAsync(i => i.Id.Equals(id));
    }

    /// <inheritdoc />
    public async Task<IEnumerable<InventoryItem>> GetInventorySummaryAsync()
    {
        return await Context.Set<InventoryItem>()
            .Include(i => i.StorageBoxes)
            .ToListAsync();
    }

    // Add this method for the new Id type without trying to override
    public async Task<InventoryItem?> FindByIdAsync(InventoryItemId id)
    {
        return await Context.Set<InventoryItem>()
            .Include(i => i.StorageBoxes)
            .FirstOrDefaultAsync(i => i.Id.Equals(id));
    }

    /// <inheritdoc />
    public new async Task<IEnumerable<InventoryItem>> ListAsync()
    {
        return await Context.Set<InventoryItem>()
            .Include(i => i.StorageBoxes)
            .ToListAsync();
    }
}