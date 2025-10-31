namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;

public record ProductIdentifier(Guid Identifier)
{
    public ProductIdentifier() : this(Guid.NewGuid())
    {
    }
}