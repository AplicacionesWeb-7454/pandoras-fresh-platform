namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to create an inventory.
/// </summary>
/// <param name="Name">
/// The name of the inventory to create.
/// </param>
/// <param name="Description">
/// The description of the inventory to create.
/// </param>
/// <param name="Location">
/// The location of the inventory to create.
/// </param>
public record CreateInventoryCommand(string Name, string Description, string Location);