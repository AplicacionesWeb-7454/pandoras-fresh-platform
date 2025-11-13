using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get product instances by inventory in the Pandora's Fresh Platform.
/// </summary>
/// <param name="InventoryId">
/// The id of the inventory to get product instances for
/// </param>
public record GetProductInstancesByInventoryQuery(InventoryItemId InventoryId);