using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;
using Microsoft.OpenApi.Extensions;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert ProductInstance to ProductInstanceResource
/// </summary>
public static class ProductInstanceResourceFromEntityAssembler
{
    /// <summary>
    /// Convert ProductInstance to ProductInstanceResource
    /// </summary>
    /// <param name="entity">
    /// The <see cref="ProductInstance" /> entity to convert
    /// </param>
    /// <returns>
    /// The <see cref="ProductInstanceResource" /> resource
    /// </returns>
    public static ProductInstanceResource ToResourceFromEntity(ProductInstance entity)
    {
        return new ProductInstanceResource(
            entity.Id,
            entity.ExpirationDate.Date,
            entity.EntryDate.Date,
            entity.Batch.Number,
            entity.Status.GetDisplayName(),
            ProductResourceFromEntityAssembler.ToResourceFromEntity(entity.Product));
    }
}