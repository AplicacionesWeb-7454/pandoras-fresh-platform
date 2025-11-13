using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;

namespace PandorasFreshPlatform.API.Inventory.Domain.Repositories;

/// <summary>
/// Represents the storage box repository in the Pandora's Fresh Platform.
/// </summary>
public interface IStorageBoxRepository : IBaseRepository<StorageBox>
{
    /// <summary>
    /// Finds storage boxes by inventory id asynchronously.
    /// </summary>
    /// <param name="inventoryId">
    /// The id of the inventory to find storage boxes for.
    /// </param>
    /// <returns>
    /// A collection of storage boxes that belong to the inventory.
    /// </returns>
    Task<IEnumerable<StorageBox>> FindByInventoryIdAsync(InventoryItemId inventoryId);

    /// <summary>
    /// Finds storage boxes with available capacity asynchronously.
    /// </summary>
    /// <param name="inventoryId">
    /// The id of the inventory to find storage boxes for.
    /// </param>
    /// <param name="requiredCapacity">
    /// The required capacity to check for.
    /// </param>
    /// <returns>
    /// A collection of storage boxes with available capacity.
    /// </returns>
    Task<IEnumerable<StorageBox>> FindStorageBoxesWithCapacityAsync(InventoryItemId inventoryId, int requiredCapacity);

    /// <summary>
    /// Gets a storage box with its content asynchronously.
    /// </summary>
    /// <param name="storageBoxId">
    /// The id of the storage box to get.
    /// </param>
    /// <returns>
    /// The storage box with its associated product instances.
    /// </returns>
    Task<StorageBox?> GetStorageBoxWithContentAsync(StorageBoxId storageBoxId);

    /// <summary>
    /// Checks if a storage box exists by label in inventory asynchronously.
    /// </summary>
    /// <param name="label">
    /// The label of the storage box to check.
    /// </param>
    /// <param name="inventoryId">
    /// The id of the inventory to check in.
    /// </param>
    /// <returns>
    /// True if a storage box with the label exists in the inventory, false otherwise.
    /// </returns>
    Task<bool> ExistsByLabelInInventoryAsync(string label, InventoryItemId inventoryId);

    /// <summary>
    /// Finds a storage box by id asynchronously using the value object.
    /// </summary>
    /// <param name="id">
    /// The id of the storage box to find.
    /// </param>
    /// <returns>
    /// The storage box with the specified id.
    /// </returns>
    Task<StorageBox?> FindByIdAsync(StorageBoxId id);
}