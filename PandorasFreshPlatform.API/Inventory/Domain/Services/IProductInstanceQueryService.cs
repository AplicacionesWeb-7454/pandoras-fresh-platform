using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the product instance query service in the Pandora's Fresh Platform.
/// </summary>
public interface IProductInstanceQueryService
{
    /// <summary>
    /// Handles the get product instances by storage box query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProductInstancesByStorageBoxQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of product instances in the storage box.
    /// </returns>
    Task<IEnumerable<ProductInstance>> Handle(GetProductInstancesByStorageBoxQuery query);

    /// <summary>
    /// Handles the get product instances by inventory query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProductInstancesByInventoryQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of product instances in the inventory.
    /// </returns>
    Task<IEnumerable<ProductInstance>> Handle(GetProductInstancesByInventoryQuery query);

    /// <summary>
    /// Handles the get product types by inventory query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProductTypesByInventoryQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of product types in the inventory.
    /// </returns>
    Task<IEnumerable<object>> Handle(GetProductTypesByInventoryQuery query);

    /// <summary>
    /// Handles the get expiring products query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetExpiringProductsQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of expiring product instances.
    /// </returns>
    Task<IEnumerable<ProductInstance>> Handle(GetExpiringProductsQuery query);

    /// <summary>
    /// Handles the get product instance by id query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProductInstanceByIdQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="ProductInstance" /> entity.
    /// </returns>
    Task<ProductInstance?> Handle(GetProductInstanceByIdQuery query);
}