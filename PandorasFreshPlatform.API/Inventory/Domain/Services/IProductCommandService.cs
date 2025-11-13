using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

namespace PandorasFreshPlatform.API.Inventory.Domain.Services;

/// <summary>
/// Represents the product command service in the Pandora's Fresh Platform.
/// </summary>
public interface IProductCommandService
{
    /// <summary>
    /// Handles the create product command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateProductCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The created <see cref="Product" /> entity.
    /// </returns>
    Task<Product?> Handle(CreateProductCommand command);

    /// <summary>
    /// Handles the update product command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="UpdateProductCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The updated <see cref="Product" /> entity.
    /// </returns>
    Task<Product?> Handle(UpdateProductCommand command);

    /// <summary>
    /// Handles the delete product command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="DeleteProductCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The result of the delete operation.
    /// </returns>
    Task<bool> Handle(DeleteProductCommand command);

    /// <summary>
    /// Handles the scan barcode command in the Pandora's Fresh Platform.
    /// </summary>
    /// <param name="command">
    /// The <see cref="ScanBarcodeCommand" /> command to handle.
    /// </param>
    /// <returns>
    /// The scanned <see cref="Product" /> entity.
    /// </returns>
    Task<Product?> Handle(ScanBarcodeCommand command);
}