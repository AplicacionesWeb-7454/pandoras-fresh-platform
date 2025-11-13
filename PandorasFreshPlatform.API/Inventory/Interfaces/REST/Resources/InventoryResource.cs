namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

/// <summary>
/// Inventory resource for REST API
/// </summary>
/// <param name="Id">
/// The unique identifier of the inventory
/// </param>
/// <param name="Name">
/// The name of the inventory
/// </param>
/// <param name="Description">
/// The description of the inventory
/// </param>
/// <param name="Location">
/// The location of the inventory
/// </param>
/// <param name="StorageBoxCount">
/// The number of storage boxes in the inventory
/// </param>
public record InventoryResource(int Id, string Name, string Description, string Location, int StorageBoxCount);