namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;

/// <summary>
///     Command to create an Inventory .
/// </summary>
/// <param name="ProductId">
///     The Id of the Product 
/// </param>
///
/// <param name="Name">
///     The name of the Product to Add to 
/// </param>
///
/// <param name="CategoryId">
///     The Id of the Category for the product
/// </param>
/// 
/// 

public record CreateProductCommand(ProductIdentifier ProductId, string Name, int CategoryId);