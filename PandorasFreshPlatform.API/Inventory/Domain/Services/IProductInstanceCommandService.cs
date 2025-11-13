using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the product instance command service in the Pandora's Fresh Platform.
/// </summary>
public interface IProductInstanceCommandService
{
    /// <summary>
    /// Handles the add product instance to storage box command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="AddProductInstanceToStorageBoxCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="ProductInstance" /> entity.
    /// </returns>
    Task<ProductInstance?> Handle(AddProductInstanceToStorageBoxCommand command);

    /// <summary>
    /// Handles the update product instance command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="UpdateProductInstanceCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The updated <see cref="ProductInstance" /> entity.
    /// </returns>
    Task<ProductInstance?> Handle(UpdateProductInstanceCommand command);

    /// <summary>
    /// Handles the remove product instance command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="RemoveProductInstanceCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The result of the remove operation.
    /// </returns>
    Task<bool> Handle(RemoveProductInstanceCommand command);

    /// <summary>
    /// Handles the transfer product instance command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="TransferProductInstanceCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The transferred <see cref="ProductInstance" /> entity.
    /// </returns>
    Task<ProductInstance?> Handle(TransferProductInstanceCommand command);

    /// <summary>
    /// Handles the batch add product instances command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="BatchAddProductInstancesCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// A collection of created <see cref="ProductInstance" /> entities.
    /// </returns>
    Task<IEnumerable<ProductInstance>> Handle(BatchAddProductInstancesCommand command);
}