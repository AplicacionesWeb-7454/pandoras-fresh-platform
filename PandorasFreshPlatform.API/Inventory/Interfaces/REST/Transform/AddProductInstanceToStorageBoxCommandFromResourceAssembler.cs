using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert AddProductInstanceToStorageBoxResource to AddProductInstanceToStorageBoxCommand
/// </summary>
public static class AddProductInstanceToStorageBoxCommandFromResourceAssembler
{
    /// <summary>
    /// Convert AddProductInstanceToStorageBoxResource to AddProductInstanceToStorageBoxCommand
    /// </summary>
    /// <param name="resource">
    /// The <see cref="AddProductInstanceToStorageBoxResource" /> resource
    /// </param>
    /// <param name="storageBoxId">
    /// The storage box id to add the product instance to
    /// </param>
    /// <returns>
    /// The <see cref="AddProductInstanceToStorageBoxCommand" /> command
    /// </returns>
    public static AddProductInstanceToStorageBoxCommand ToCommandFromResource(
        AddProductInstanceToStorageBoxResource resource, StorageBoxId storageBoxId)
    {
        return new AddProductInstanceToStorageBoxCommand(
            resource.ExpirationDate,
            resource.EntryDate,
            resource.BatchNumber,
            new ProductId(resource.ProductId),
            storageBoxId);
    }
}