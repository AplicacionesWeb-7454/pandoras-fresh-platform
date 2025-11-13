using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert UpdateInventoryResource to UpdateInventoryCommand
/// </summary>
public static class UpdateInventoryCommandFromResourceAssembler
{
    /// <summary>
    /// Convert UpdateInventoryResource to UpdateInventoryCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="UpdateInventoryResource" /> resource
    /// </param>
    /// <param name="inventoryId">
    /// The inventory id to update
    /// </param>
    /// <returns>
    /// The <see cref="UpdateInventoryCommand" /> command
    /// </returns>
    public static UpdateInventoryCommand ToCommandFromResource(UpdateInventoryResource resource, InventoryItemId inventoryId)
    {
        return new UpdateInventoryCommand(inventoryId, resource.Name, resource.Description, resource.Location);
    }
}