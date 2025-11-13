using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a storage box with detailed information in the Pandora's Fresh Platform.
/// </summary>
/// <param name="StorageBoxId">
/// The id of the storage box to get with details
/// </param>
public record GetStorageBoxWithDetailsQuery(StorageBoxId StorageBoxId);