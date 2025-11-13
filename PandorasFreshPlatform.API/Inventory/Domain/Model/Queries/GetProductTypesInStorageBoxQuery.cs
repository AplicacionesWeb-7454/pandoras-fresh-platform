using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Queries;

/// <summary>
/// Represents a query to get product types in a storage box in the Pandora's Fresh Platform.
/// </summary>
/// <param name="StorageBoxId">
/// The id of the storage box to get product types for
/// </param>
public record GetProductTypesInStorageBoxQuery(StorageBoxId StorageBoxId);