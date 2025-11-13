using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert StorageBox to StorageBoxResource
/// </summary>
public static class StorageBoxResourceFromEntityAssembler
{
    /// <summary>
    /// Convert StorageBox to StorageBoxResource
    /// </summary>
    /// <param name="entity">
    /// The <see cref="StorageBox" /> entity
    /// </param>
    /// <returns>
    /// The <see cref="StorageBoxResource" /> resource
    /// </returns>
    public static StorageBoxResource ToResourceFromEntity(StorageBox entity)
    {
        return new StorageBoxResource(
            entity.Id,
            entity.Label,
            entity.Capacity.Max,
            entity.Capacity.Current,
            entity.StorageConditions.TemperatureRange,
            entity.ProductInstances.Count);
    }
}