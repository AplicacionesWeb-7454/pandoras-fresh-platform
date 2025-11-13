using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert UpdateStorageBoxResource to UpdateStorageBoxCommand
/// </summary>
public static class UpdateStorageBoxCommandFromResourceAssembler
{
    /// <summary>
    /// Convert UpdateStorageBoxResource to UpdateStorageBoxCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="UpdateStorageBoxResource" /> resource
    /// </param>
    /// <param name="storageBoxId">
    /// The storage box id to update
    /// </param>
    /// <returns>
    /// The <see cref="UpdateStorageBoxCommand" /> command
    /// </returns>
    public static UpdateStorageBoxCommand ToCommandFromResource(UpdateStorageBoxResource resource, StorageBoxId storageBoxId)
    {
        return new UpdateStorageBoxCommand(
            storageBoxId,
            resource.Label,
            resource.MaxCapacity,
            resource.CurrentCapacity,
            resource.TemperatureRange);
    }
}