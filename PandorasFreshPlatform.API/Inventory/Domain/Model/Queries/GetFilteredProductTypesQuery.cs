using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get filtered product types in the Pandora's Fresh Platform.
/// </summary>
/// <param name="CategoryId">
/// The category id to filter by
/// </param>
/// <param name="InventoryId">
/// The inventory id to filter by
/// </param>
public record GetFilteredProductTypesQuery(CategoryId? CategoryId, InventoryItemId? InventoryId);