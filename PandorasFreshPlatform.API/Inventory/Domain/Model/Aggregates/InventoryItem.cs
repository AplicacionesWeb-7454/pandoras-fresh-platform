using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;

/// <summary>
/// Inventory aggregate root entity
/// </summary>
public partial class InventoryItem
{
    /// <summary>
    /// Default constructor for the inventory entity
    /// </summary>
    public InventoryItem()
    {
        Name = string.Empty;
        Description = string.Empty;
        Location = new Location(string.Empty);
        StorageBoxes = new List<StorageBox>();
    }

    /// <summary>
    /// Constructor for the inventory entity
    /// </summary>
    public InventoryItem(string name, string description, Location location) : this()
    {
        Name = name;
        Description = description;
        Location = location;
    }

    public InventoryItem(CreateInventoryCommand command) : this(command.Name, command.Description, 
        new Location(command.Location))
    {
    }

    public InventoryItemId Id { get; }  // Changed from int to InventoryItemId
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Location Location { get; private set; }
    public ICollection<StorageBox> StorageBoxes { get; }

    /// <summary>
    /// Add a storage box to the inventory
    /// </summary>
    public void AddStorageBox(StorageBox storageBox)
    {
        if (StorageBoxes.Any(b => b.Label == storageBox.Label)) return;
        StorageBoxes.Add(storageBox);
    }

    /// <summary>
    /// Remove a storage box from the inventory
    /// </summary>
    public void RemoveStorageBox(StorageBoxIdentifier identifier)
    {
        var storageBox = StorageBoxes.FirstOrDefault(b => b.BoxIdentifier == identifier);
        if (storageBox is null) return;
        StorageBoxes.Remove(storageBox);
    }

    /// <summary>
    /// Update inventory information
    /// </summary>
    public void UpdateInformation(string name, string description, Location location)
    {
        Name = name;
        Description = description;
        Location = location;
    }
}