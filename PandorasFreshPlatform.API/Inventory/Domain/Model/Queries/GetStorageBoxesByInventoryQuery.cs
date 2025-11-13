using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get storage boxes by inventory in the Pandora's Fresh Platform.
/// </summary>
/// <param name="InventoryId">
/// The id of the inventory to get storage boxes for
/// </param>
public record GetStorageBoxesByInventoryQuery(InventoryItemId InventoryId);