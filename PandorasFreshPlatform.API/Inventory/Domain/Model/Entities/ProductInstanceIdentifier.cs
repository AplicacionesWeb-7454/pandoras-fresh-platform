namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;

/// <summary>
/// Represents an identifier for a product instance in the Pandora's Fresh Platform
/// </summary>
public record ProductInstanceIdentifier(Guid Identifier)
{
    public ProductInstanceIdentifier() : this(Guid.NewGuid())
    {
    }
}