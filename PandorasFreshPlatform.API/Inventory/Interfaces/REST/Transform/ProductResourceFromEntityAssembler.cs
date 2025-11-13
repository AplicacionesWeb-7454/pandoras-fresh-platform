using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert Product to ProductResource
/// </summary>
public static class ProductResourceFromEntityAssembler
{
    /// <summary>
    /// Convert Product to ProductResource
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Product" /> entity
    /// </param>
    /// <returns>
    /// The <see cref="ProductResource" /> resource
    /// </returns>
    public static ProductResource ToResourceFromEntity(Product entity)
    {
        return new ProductResource(
            entity.Id,
            entity.Name,
            entity.Description,
            entity.Barcode.Code,
            CategoryResourceFromEntityAssembler.ToResourceFromEntity(entity.Category));
    }
}