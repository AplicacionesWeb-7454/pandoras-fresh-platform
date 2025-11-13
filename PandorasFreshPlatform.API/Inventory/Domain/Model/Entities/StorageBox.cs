using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;
using PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;

/// <summary>
/// Represents a storage box in the Pandora's Fresh Platform
/// </summary>
public partial class StorageBox
{
    /// <summary>
    /// Default constructor for the storage box entity
    /// </summary>
    public StorageBox()
    {
        Label = string.Empty;
        Capacity = new Capacity(0, 0);
        StorageConditions = new StorageConditions("Default Temperature Range");
        ProductInstances = new List<ProductInstance>();
    }

    /// <summary>
    /// Constructor for the storage box entity
    /// </summary>
    public StorageBox(string label, Capacity capacity, StorageConditions storageConditions, int inventoryId) : this()
    {
        Label = label;
        Capacity = capacity;
        StorageConditions = storageConditions;
        InventoryId = inventoryId;
    }

    public StorageBox(CreateStorageBoxCommand command) : this(command.Label, 
        new Capacity(command.MaxCapacity, command.CurrentCapacity), 
        new StorageConditions(command.TemperatureRange),
        command.InventoryId)
    {
    }

    public int Id { get; }
    public StorageBoxIdentifier BoxIdentifier { get; private set; } = new();
    public string Label { get; private set; }
    public Capacity Capacity { get; private set; }
    public StorageConditions StorageConditions { get; private set; }
    public int InventoryId { get; private set; }
    public InventoryItem Inventory { get; private set; }
    public ICollection<ProductInstance> ProductInstances { get; }

    /// <summary>
    /// Check if the box has available capacity
    /// </summary>
    public bool HasAvailableCapacity()
    {
        return Capacity.Current < Capacity.Max;
    }

    /// <summary>
    /// Add a product instance to the box
    /// </summary>
    public void AddProductInstance(ProductInstance productInstance)
    {
        if (!HasAvailableCapacity()) 
            throw new InvalidOperationException("Storage box has no available capacity");
        
        ProductInstances.Add(productInstance);
        productInstance.AssignToStorageBox(this);
        Capacity = Capacity with { Current = Capacity.Current + 1 };
    }

    /// <summary>
    /// Remove a product instance from the box
    /// </summary>
    public void RemoveProductInstance(ProductInstanceIdentifier identifier)
    {
        var productInstance = ProductInstances.FirstOrDefault(p => p.InstanceIdentifier == identifier);
        if (productInstance is null) return;
        
        ProductInstances.Remove(productInstance);
        productInstance.RemoveFromStorageBox();
        Capacity = Capacity with { Current = Capacity.Current - 1 };
    }

    /// <summary>
    /// Remove a product instance from the box by instance
    /// </summary>
    public void RemoveProductInstance(ProductInstance productInstance)
    {
        if (ProductInstances.Remove(productInstance))
        {
            productInstance.RemoveFromStorageBox();
            Capacity = Capacity with { Current = Capacity.Current - 1 };
        }
    }

    /// <summary>
    /// Update storage box information
    /// </summary>
    public void UpdateInformation(string label, Capacity capacity, StorageConditions storageConditions)
    {
        Label = label;
        Capacity = capacity;
        StorageConditions = storageConditions;
    }

    /// <summary>
    /// Check if product instance exists in this box
    /// </summary>
    public bool ContainsProductInstance(ProductInstanceIdentifier identifier)
    {
        return ProductInstances.Any(p => p.InstanceIdentifier == identifier);
    }

    /// <summary>
    /// Get available capacity count
    /// </summary>
    public int GetAvailableCapacity()
    {
        return Capacity.Max - Capacity.Current;
    }
}