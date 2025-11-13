using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert CreateProductResource to CreateProductCommand
/// </summary>
public static class CreateProductCommandFromResourceAssembler
{
    /// <summary>
    /// Convert CreateProductResource to CreateProductCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateProductResource" /> resource
    /// </param>
    /// <returns>
    /// The <see cref="CreateProductCommand" /> command
    /// </returns>
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(
            resource.Name, 
            resource.Description, 
            resource.Barcode, 
            new CategoryId(resource.CategoryId));
    }
}