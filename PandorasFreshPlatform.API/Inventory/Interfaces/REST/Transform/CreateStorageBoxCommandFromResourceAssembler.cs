using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert CreateStorageBoxResource to CreateStorageBoxCommand
/// </summary>
public static class CreateStorageBoxCommandFromResourceAssembler
{
    /// <summary>
    /// Convert CreateStorageBoxResource to CreateStorageBoxCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateStorageBoxResource" /> resource
    /// </param>
    /// <param name="inventoryId">
    /// The inventory id to add the storage box to
    /// </param>
    /// <returns>
    /// The <see cref="CreateStorageBoxCommand" /> command
    /// </returns>
    public static CreateStorageBoxCommand ToCommandFromResource(CreateStorageBoxResource resource, InventoryItemId inventoryId)
    {
        return new CreateStorageBoxCommand(
            resource.Label,
            resource.MaxCapacity,
            resource.CurrentCapacity,
            resource.TemperatureRange,
            inventoryId);
    }
}