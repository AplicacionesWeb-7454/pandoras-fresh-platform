using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to update an inventory.
/// </summary>
/// <param name="InventoryId">
/// The ID of the inventory to update.
/// </param>
/// <param name="Name">
/// The updated name of the inventory.
/// </param>
/// <param name="Description">
/// The updated description of the inventory.
/// </param>
/// <param name="Location">
/// The updated location of the inventory.
/// </param>
public record UpdateInventoryCommand(
    InventoryItemId InventoryId, 
    string Name, 
    string Description, 
    string Location
);