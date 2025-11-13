using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert Inventory to InventoryResource
/// </summary>
public static class InventoryResourceFromEntityAssembler
{
    /// <summary>
    /// Convert Inventory to InventoryResource
    /// </summary>
    /// <param name="entity">
    /// The <see cref="InventoryItem" /> entity
    /// </param>
    /// <returns>
    /// The <see cref="InventoryResource" /> resource
    /// </returns>
    public static InventoryResource ToResourceFromEntity(InventoryItem entity)
    {
        return new InventoryResource(
            entity.Id.Id,
            entity.Name,
            entity.Description,
            entity.Location.Value,
            entity.StorageBoxes.Count);
    }
}