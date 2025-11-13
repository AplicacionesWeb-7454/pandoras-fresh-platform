using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to delete an inventory.
/// </summary>
/// <param name="InventoryId">
/// The ID of the inventory to delete.
/// </param>
public record DeleteInventoryCommand(InventoryItemId InventoryId);