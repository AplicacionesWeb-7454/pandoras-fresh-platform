using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a product instance by id in the Pandora's Fresh Platform.
/// </summary>
/// <param name="ProductInstanceId">
/// The id of the product instance to get
/// </param>
public record GetProductInstanceByIdQuery(ProductInstanceId ProductInstanceId);