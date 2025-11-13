using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert CreateInventoryResource to CreateInventoryCommand
/// </summary>
public static class CreateInventoryCommandFromResourceAssembler
{
    /// <summary>
    /// Convert CreateInventoryResource to CreateInventoryCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateInventoryResource" /> resource
    /// </param>
    /// <returns>
    /// The <see cref="CreateInventoryCommand" /> command
    /// </returns>
    public static CreateInventoryCommand ToCommandFromResource(CreateInventoryResource resource)
    {
        return new CreateInventoryCommand(resource.Name, resource.Description, resource.Location);
    }
}