using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Repositories;

/// <summary>
/// Represents the product query repository in the Pandora's Fresh Platform.
/// </summary>
public interface IProductQueryRepository
{
    /// <summary>
    /// Gets product types by inventory asynchronously.
    /// </summary>
    /// <param name="inventoryId">
    /// The id of the inventory to get product types for.
    /// </param>
    /// <returns>
    /// A collection of product types in the inventory.
    /// </returns>
    Task<IEnumerable<Product>> GetProductTypesByInventoryAsync(InventoryItemId inventoryId);

    /// <summary>
    /// Gets product types by storage box asynchronously.
    /// </summary>
    /// <param name="storageBoxId">
    /// The id of the storage box to get product types for.
    /// </param>
    /// <returns>
    /// A collection of product types in the storage box.
    /// </returns>
    Task<IEnumerable<Product>> GetProductTypesByStorageBoxAsync(StorageBoxId storageBoxId);

    /// <summary>
    /// Gets filtered product instances asynchronously.
    /// </summary>
    /// <param name="categoryId">
    /// The category id to filter by.
    /// </param>
    /// <param name="status">
    /// The status to filter by.
    /// </param>
    /// <param name="inventoryId">
    /// The inventory id to filter by.
    /// </param>
    /// <param name="storageBoxId">
    /// The storage box id to filter by.
    /// </param>
    /// <returns>
    /// A collection of filtered product instances.
    /// </returns>
    Task<IEnumerable<ProductInstance>> GetFilteredProductInstancesAsync(CategoryId? categoryId, string? status, InventoryItemId? inventoryId, StorageBoxId? storageBoxId);

    /// <summary>
    /// Gets filtered product types asynchronously.
    /// </summary>
    /// <param name="categoryId">
    /// The category id to filter by.
    /// </param>
    /// <param name="inventoryId">
    /// The inventory id to filter by.
    /// </param>
    /// <returns>
    /// A collection of filtered product types.
    /// </returns>
    Task<IEnumerable<Product>> GetFilteredProductTypesAsync(CategoryId? categoryId, InventoryItemId? inventoryId);

    /// <summary>
    /// Gets inventory quick view asynchronously.
    /// </summary>
    /// <returns>
    /// A collection of inventory quick view data.
    /// </returns>
    Task<IEnumerable<object>> GetInventoryQuickViewAsync();
}