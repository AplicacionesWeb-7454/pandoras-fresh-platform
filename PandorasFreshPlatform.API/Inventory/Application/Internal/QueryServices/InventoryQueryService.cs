using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;
using PandorasFreshPlatform.API.Inventory.Domain.Repositories;
using PandorasFreshPlatform.API.Inventory.Domain.Services;

namespace PandorasFreshPlatform.API.Inventory.Application.Internal.QueryServices;

/// <summary>
/// Represents the inventory query service in the Pandora's Fresh Platform.
/// </summary>
/// <param name="inventoryRepository">
/// The <see cref="IInventoryRepository" /> to use.
/// </param>
public class InventoryQueryService(IInventoryRepository inventoryRepository)
    : IInventoryQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<InventoryItem>> Handle(GetAllInventoriesQuery query)
    {
        return await inventoryRepository.ListAsync();
    }

    /// <inheritdoc />
    public async Task<InventoryItem?> Handle(GetInventoryByIdQuery query)
    {
        return await inventoryRepository.FindByIdAsync(query.InventoryId);
    }

    /// <inheritdoc />
    public async Task<object> Handle(GetInventorySummaryQuery query)
    {
        var inventory = await inventoryRepository.FindByIdAsync(query.InventoryId);
        if (inventory is null) throw new Exception("Inventory not found");

        // Return summary data - in a real implementation, this would be a dedicated DTO
        return new
        {
            InventoryId = inventory.Id,
            InventoryName = inventory.Name,
            TotalStorageBoxes = inventory.StorageBoxes.Count,
            TotalCapacity = inventory.StorageBoxes.Sum(b => b.Capacity.Max),
            UsedCapacity = inventory.StorageBoxes.Sum(b => b.Capacity.Current)
        };
    }

    /// <inheritdoc />
    public async Task<InventoryItem?> Handle(GetInventoryWithStorageBoxesQuery query)
    {
        return await inventoryRepository.GetWithStorageBoxesAsync(query.InventoryId);
    }
}