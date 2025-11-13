using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get a storage box by id in the Pandora's Fresh Platform.
/// </summary>
/// <param name="StorageBoxId">
/// The id of the storage box to get
/// </param>
public record GetStorageBoxByIdQuery(StorageBoxId StorageBoxId);