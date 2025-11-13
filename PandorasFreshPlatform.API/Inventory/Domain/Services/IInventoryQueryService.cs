using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the inventory query service in the Pandora's Fresh Platform.
/// </summary>
public interface IInventoryQueryService
{
    /// <summary>
    /// Handles the get all inventories query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllInventoriesQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// A collection of all inventories in the platform.
    /// </returns>
    Task<IEnumerable<InventoryItem>> Handle(GetAllInventoriesQuery query);

    /// <summary>
    /// Handles the get inventory by id query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetInventoryByIdQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="InventoryItem" /> entity.
    /// </returns>
    Task<InventoryItem?> Handle(GetInventoryByIdQuery query);

    /// <summary>
    /// Handles the get inventory summary query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetInventorySummaryQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// The inventory summary data.
    /// </returns>
    Task<object> Handle(GetInventorySummaryQuery query);

    /// <summary>
    /// Handles the get inventory with storage boxes query in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetInventoryWithStorageBoxesQuery" /> query to handle.
    /// </param>
    /// <returns>
    /// The <see cref="InventoryItem" /> entity with its storage boxes.
    /// </returns>
    Task<InventoryItem?> Handle(GetInventoryWithStorageBoxesQuery query);
}