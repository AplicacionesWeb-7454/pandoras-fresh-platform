using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;

/// <summary>
/// Represents a product instance in the Pandora's Fresh Platform
/// </summary>
public partial class ProductInstance
{
    /// <summary>
    /// Default constructor for the product instance entity
    /// </summary>
    public ProductInstance()
    {
        Batch = new Batch(string.Empty);
        Status = EProductStatus.Fresh;
    }

    /// <summary>
    /// Constructor for the product instance entity
    /// </summary>
    public ProductInstance(ExpirationDate expirationDate, EntryDate entryDate, Batch batch, int productId) : this()
    {
        ExpirationDate = expirationDate;
        EntryDate = entryDate;
        Batch = batch;
        ProductId = productId;
    }

    public ProductInstance(AddProductInstanceToStorageBoxCommand command) : this(
        new ExpirationDate(command.ExpirationDate),
        new EntryDate(command.EntryDate),
        new Batch(command.BatchNumber),
        command.ProductId.Value) // FIX: Extract the Value from ProductId
    {
    }

    public int Id { get; }
    public ProductInstanceIdentifier InstanceIdentifier { get; private set; } = new();
    public ExpirationDate ExpirationDate { get; private set; }
    public EntryDate EntryDate { get; private set; }
    public Batch Batch { get; private set; }
    public EProductStatus Status { get; private set; }
    public Product Product { get; internal set; }
    public int ProductId { get; private set; }


    public int? StorageBoxId { get; private set; }

    /// <summary>
    /// Update product instance status based on expiration date
    /// </summary>
    public void UpdateStatus()
    {
        var daysUntilExpiration = (ExpirationDate.Date - DateTime.UtcNow).Days;
        Status = daysUntilExpiration switch
        {
            <= 0 => EProductStatus.Expired,
            <= 2 => EProductStatus.ExpiringSoon, // Within 2 days
            _ => EProductStatus.Fresh
        };
    }

    /// <summary>
    /// Check if product instance is expired
    /// </summary>
    public bool IsExpired()
    {
        return ExpirationDate.Date <= DateTime.UtcNow;
    }

    /// <summary>
    /// Assign this product instance to a storage box
    /// </summary>
    public void AssignToStorageBox(StorageBox storageBox)
    {
        StorageBoxId = storageBox.Id;
    }

    /// <summary>
    /// Remove this product instance from its storage box
    /// </summary>
    public void RemoveFromStorageBox()
    {
        StorageBoxId = null;
    }
}