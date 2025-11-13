using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the storage box command service in the Pandora's Fresh Platform.
/// </summary>
public interface IStorageBoxCommandService
{
    /// <summary>
    /// Handles the create storage box command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateStorageBoxCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="StorageBox" /> entity.
    /// </returns>
    Task<StorageBox?> Handle(CreateStorageBoxCommand command);

    /// <summary>
    /// Handles the update storage box command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="UpdateStorageBoxCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The updated <see cref="StorageBox" /> entity.
    /// </returns>
    Task<StorageBox?> Handle(UpdateStorageBoxCommand command);

    /// <summary>
    /// Handles the delete storage box command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="DeleteStorageBoxCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The result of the delete operation.
    /// </returns>
    Task<bool> Handle(DeleteStorageBoxCommand command);
}