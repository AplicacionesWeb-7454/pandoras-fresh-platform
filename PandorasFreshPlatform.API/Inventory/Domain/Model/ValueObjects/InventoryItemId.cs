// InventoryItemId.cs
namespace PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

/// <summary>
/// Represents the inventory item identifier in the Pandora's Fresh Platform.
/// </summary>
/// <param name="Id">The id of the inventory item.</param>
public record InventoryItemId(int Id);