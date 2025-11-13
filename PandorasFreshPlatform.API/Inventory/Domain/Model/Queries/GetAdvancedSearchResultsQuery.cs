using PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query for advanced product search in the Pandora's Fresh Platform.
/// </summary>
/// <param name="SearchTerm">
/// The term to search for in product names, descriptions, and barcodes
/// </param>
/// <param name="CategoryId">
/// The category id to filter by (optional)
/// </param>
/// <param name="InventoryId">
/// The inventory id to filter by (optional)
/// </param>
/// <param name="StorageBoxId">
/// The storage box id to filter by (optional)
/// </param>
/// <param name="Status">
/// The status to filter by (optional)
/// </param>
/// <param name="MinQuantity">
/// The minimum quantity to filter by (optional)
/// </param>
/// <param name="MaxQuantity">
/// The maximum quantity to filter by (optional)
/// </param>
public record GetAdvancedSearchResultsQuery(
    string? SearchTerm,
    CategoryId? CategoryId,
    InventoryItemId? InventoryId,
    StorageBoxId? StorageBoxId,
    string? Status,
    int? MinQuantity,
    int? MaxQuantity);