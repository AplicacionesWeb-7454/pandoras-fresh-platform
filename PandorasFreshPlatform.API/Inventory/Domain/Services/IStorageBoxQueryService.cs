using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the storage box query service in the Pandora's Fresh Platform.
/// </summary>
public interface IStorageBoxQueryService
{
    /// <summary>
    /// Handles the get storage box by id query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetStorageBoxByIdQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="StorageBox" /> entity.
    /// </returns>
    Task<StorageBox?> Handle(GetStorageBoxByIdQuery query);

    /// <summary>
    /// Handles the get storage boxes by inventory query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetStorageBoxesByInventoryQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of storage boxes that belong to the inventory.
    /// </returns>
    Task<IEnumerable<StorageBox>> Handle(GetStorageBoxesByInventoryQuery query);

    /// <summary>
    /// Handles the get storage box content query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetStorageBoxContentQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of product instances in the storage box.
    /// </returns>
    Task<IEnumerable<object>> Handle(GetStorageBoxContentQuery query);

    /// <summary>
    /// Handles the get product types in storage box query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetProductTypesInStorageBoxQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of product types in the storage box.
    /// </returns>
    Task<IEnumerable<object>> Handle(GetProductTypesInStorageBoxQuery query);

    
}