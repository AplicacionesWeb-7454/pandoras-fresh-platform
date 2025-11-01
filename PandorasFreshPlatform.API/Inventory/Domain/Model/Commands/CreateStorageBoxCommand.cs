using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
///     Command to create an Inventory .
/// </summary>
/// <param name="StorageBoxId">
///     The Id of the Storage Box 
/// </param>
///
/// <param name="Name">
///     The name of the Storage Box 
/// </param>
///
/// <param name="BoxType">
///     The Type of the Storage Box
/// </param>
///
///<param name="SensorId"> 
///     The Id of the Sensor of the Storage Box
/// </param> 
/// 

public record CreateStorageBoxCommand(int StorageBoxId, string Name, BoxType BoxType, string? SensorId = null); 