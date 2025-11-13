using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to remove a product instance.
/// </summary>
/// <param name="ProductInstanceId">
/// The ID of the product instance to remove.
/// </param>
public record RemoveProductInstanceCommand(ProductInstanceId ProductInstanceId);