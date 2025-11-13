using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;

namespace PandorasFreshPlatform.API.Inventory.Domain.Repositories;

/// <summary>
/// Represents the inventory repository in the Pandora's Fresh Platform.
/// </summary>
public interface IInventoryRepository : IBaseRepository<InventoryItem>
{
    /// <summary>
    /// Finds an inventory by name asynchronously.
    /// </summary>
    /// <param name="name">
    /// The name of the inventory to find.
    /// </param>
    /// <returns>
    /// The inventory with the specified name.
    /// </returns>
    Task<InventoryItem?> FindByNameAsync(string name);

    /// <summary>
    /// Gets an inventory with its storage boxes asynchronously.
    /// </summary>
    /// <param name="id">
    /// The id of the inventory to get.
    /// </param>
    /// <returns>
    /// The inventory with its associated storage boxes.
    /// </returns>
    Task<InventoryItem?> GetWithStorageBoxesAsync(InventoryItemId id);

    /// <summary>
    /// Gets inventory summary asynchronously.
    /// </summary>
    /// <returns>
    /// A collection of inventory summaries.
    /// </returns>
    Task<IEnumerable<InventoryItem>> GetInventorySummaryAsync();

    /// <summary>
    /// Finds an inventory by id asynchronously using the value object.
    /// </summary>
    /// <param name="id">
    /// The id of the inventory to find.
    /// </param>
    /// <returns>
    /// The inventory with the specified id.
    /// </returns>
    Task<InventoryItem?> FindByIdAsync(InventoryItemId id);
}