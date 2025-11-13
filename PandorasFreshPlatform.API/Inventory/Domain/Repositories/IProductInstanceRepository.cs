using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;

namespace PandorasFreshPlatform.API.Inventory.Domain.Repositories;

/// <summary>
/// Represents the product instance repository in the Pandora's Fresh Platform.
/// </summary>
public interface IProductInstanceRepository : IBaseRepository<ProductInstance>
{
    /// <summary>
    /// Finds product instances by storage box id asynchronously.
    /// </summary>
    /// <param name="storageBoxId">
    /// The id of the storage box to find product instances for.
    /// </param>
    /// <returns>
    /// A collection of product instances in the storage box.
    /// </returns>
    Task<IEnumerable<ProductInstance>> FindByStorageBoxIdAsync(StorageBoxId storageBoxId);

    /// <summary>
    /// Finds product instances by inventory id asynchronously.
    /// </summary>
    /// <param name="inventoryId">
    /// The id of the inventory to find product instances for.
    /// </param>
    /// <returns>
    /// A collection of product instances in the inventory.
    /// </returns>
    Task<IEnumerable<ProductInstance>> FindByInventoryIdAsync(InventoryItemId inventoryId);

    /// <summary>
    /// Finds expiring products asynchronously.
    /// </summary>
    /// <param name="threshold">
    /// The expiration threshold date.
    /// </param>
    /// <returns>
    /// A collection of product instances expiring before the threshold.
    /// </returns>
    Task<IEnumerable<ProductInstance>> FindExpiringProductsAsync(DateTime threshold);

    /// <summary>
    /// Finds product instances by product id asynchronously.
    /// </summary>
    /// <param name="productId">
    /// The id of the product to find instances for.
    /// </param>
    /// <returns>
    /// A collection of product instances of the specified product.
    /// </returns>
    Task<IEnumerable<ProductInstance>> FindByProductIdAsync(ProductId productId);

    /// <summary>
    /// Gets product instances with details asynchronously.
    /// </summary>
    /// <returns>
    /// A collection of product instances with product details.
    /// </returns>
    Task<IEnumerable<ProductInstance>> GetProductInstancesWithDetailsAsync();

    /// <summary>
    /// Finds product instances by status asynchronously.
    /// </summary>
    /// <param name="status">
    /// The status to filter by.
    /// </param>
    /// <returns>
    /// A collection of product instances with the specified status.
    /// </returns>
    Task<IEnumerable<ProductInstance>> FindByStatusAsync(EProductStatus status);

    /// <summary>
    /// Finds a product instance by id asynchronously using the value object.
    /// </summary>
    /// <param name="id">
    /// The id of the product instance to find.
    /// </param>
    /// <returns>
    /// The product instance with the specified id.
    /// </returns>
    Task<ProductInstance?> FindByIdAsync(ProductInstanceId id);
}