namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

/// <summary>
/// Storage box resource for REST API
/// </summary>
/// <param name="Id">
/// The unique identifier of the storage box
/// </param>
/// <param name="Label">
/// The label of the storage box
/// </param>
/// <param name="MaxCapacity">
/// The maximum capacity of the storage box
/// </param>
/// <param name="CurrentCapacity">
/// The current capacity of the storage box
/// </param>
/// <param name="TemperatureRange">
/// The temperature range for the storage box
/// </param>
/// <param name="ProductInstanceCount">
/// The number of product instances in the storage box
/// </param>
public record StorageBoxResource(int Id, string Label, int MaxCapacity, int CurrentCapacity, string TemperatureRange, int ProductInstanceCount);