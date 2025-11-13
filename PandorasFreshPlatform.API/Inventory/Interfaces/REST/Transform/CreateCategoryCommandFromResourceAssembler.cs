using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert CreateCategoryResource to CreateCategoryCommand
/// </summary>
public static class CreateCategoryCommandFromResourceAssembler
{
    /// <summary>
    /// Convert CreateCategoryResource to CreateCategoryCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="CreateCategoryResource" /> resource
    /// </param>
    /// <returns>
    /// The <see cref="CreateCategoryCommand" /> command
    /// </returns>
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
}