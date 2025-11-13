using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get storage box content in the Pandora's Fresh Platform.
/// </summary>
/// <param name="StorageBoxId">
/// The id of the storage box to get content for
/// </param>
public record GetStorageBoxContentQuery(StorageBoxId StorageBoxId);