using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the category command service in the Pandora's Fresh Platform.
/// </summary>
public interface ICategoryCommandService
{
    /// <summary>
    /// Handles the create category command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateCategoryCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Category" /> entity.
    /// </returns>
    Task<Category?> Handle(CreateCategoryCommand command);
}