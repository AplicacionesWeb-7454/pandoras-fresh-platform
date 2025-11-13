using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get an inventory by id in the Pandora's Fresh Platform.
/// </summary>
/// <param name="InventoryId">
/// The id of the inventory to get
/// </param>
public record GetInventoryByIdQuery(InventoryItemId InventoryId);