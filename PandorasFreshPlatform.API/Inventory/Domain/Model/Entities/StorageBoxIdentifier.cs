namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;

/// <summary>
/// Represents an identifier for a storage box in the Pandora's Fresh Platform
/// </summary>
public record StorageBoxIdentifier(Guid Identifier)
{
    public StorageBoxIdentifier() : this(Guid.NewGuid())
    {
    }
}