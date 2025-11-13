namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

/// <summary>
/// Create inventory resource for REST API
/// </summary>
/// <param name="Name">
/// The name of the inventory
/// </param>
/// <param name="Description">
/// The description of the inventory
/// </param>
/// <param name="Location">
/// The location of the inventory
/// </param>
public record CreateInventoryResource(string Name, string Description, string Location);