using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert UpdateProductResource to UpdateProductCommand
/// </summary>
public static class UpdateProductCommandFromResourceAssembler
{
    /// <summary>
    /// Convert UpdateProductResource to UpdateProductCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="UpdateProductResource" /> resource
    /// </param>
    /// <param name="productId">
    /// The product id to update
    /// </param>
    /// <returns>
    /// The <see cref="UpdateProductCommand" /> command
    /// </returns>
    public static UpdateProductCommand ToCommandFromResource(UpdateProductResource resource, ProductId productId)
    {
        return new UpdateProductCommand(
            productId, 
            resource.Name, 
            resource.Description, 
            resource.Barcode, 
            new CategoryId(resource.CategoryId));
    }
}