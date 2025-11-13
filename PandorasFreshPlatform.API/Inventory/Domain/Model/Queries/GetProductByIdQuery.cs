using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a product by id in the Pandora's Fresh Platform.
/// </summary>
/// <param name="ProductId">
/// The id of the product to get
/// </param>
public record GetProductByIdQuery(ProductId ProductId);