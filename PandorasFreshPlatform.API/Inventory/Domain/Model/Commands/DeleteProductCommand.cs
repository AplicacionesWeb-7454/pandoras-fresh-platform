using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to delete a product.
/// </summary>
/// <param name="ProductId">
/// The ID of the product to delete.
/// </param>
public record DeleteProductCommand(ProductId ProductId);