namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to add multiple product instances in a batch operation.
/// </summary>
/// <param name="ProductInstances">
/// Collection of product instances to add.
/// </param>
public record BatchAddProductInstancesCommand(IEnumerable<AddProductInstanceToStorageBoxCommand> ProductInstances);