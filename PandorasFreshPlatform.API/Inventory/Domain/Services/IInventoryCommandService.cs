using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the inventory command service in the Pandora's Fresh Platform.
/// </summary>
public interface IInventoryCommandService
{
    /// <summary>
    /// Handles the create inventory command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateInventoryCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="InventoryItem" /> entity.
    /// </returns>
    Task<InventoryItem?> Handle(CreateInventoryCommand command);

    /// <summary>
    /// Handles the update inventory command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="UpdateInventoryCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The updated <see cref="InventoryItem" /> entity.
    /// </returns>
    Task<InventoryItem?> Handle(UpdateInventoryCommand command);

    /// <summary>
    /// Handles the delete inventory command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="DeleteInventoryCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The result of the delete operation.
    /// </returns>
    Task<bool> Handle(DeleteInventoryCommand command);
}