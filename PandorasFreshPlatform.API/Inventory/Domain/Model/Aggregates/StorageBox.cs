using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;

public partial class StorageBox : IEntityWithCreatedUpdatedDate
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public BoxType Type { get; private set; }
    public int TotalCapacity { get; private set; }
    public int UsedCapacity => BoxItems.Sum(item => item.Quantity);
    public decimal UtilizationRate => TotalCapacity > 0 ? (decimal)UsedCapacity / TotalCapacity : 0;
    public string? SensorId { get; private set; }
    public EInventoryStatus Status { get; private set; }
    
    private readonly List<BoxItem> _boxItems = new();
    public IReadOnlyCollection<BoxItem> BoxItems => _boxItems.AsReadOnly();
    
    [Column("CreatedAt")] 
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] 
    public DateTimeOffset? UpdatedDate { get; set; }
    
    private StorageBox()
    {
        Name = string.Empty;
        Status = EInventoryStatus.Active;
    }
    
    public StorageBox(string name, BoxType type, int totalCapacity, string? sensorId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Box name is required");
            
        if (totalCapacity <= 0)
            throw new ArgumentException("Capacity must be positive");
        
        Name = name.Trim();
        Type = type;
        TotalCapacity = totalCapacity;
        SensorId = sensorId;
        Status = EInventoryStatus.Active;
    }
    
    public void UpdateCapacity(int newCapacity)
    {
        if (newCapacity <= 0)
            throw new ArgumentException("Capacity must be positive");
            
        if (newCapacity < UsedCapacity)
            throw new InvalidOperationException("Cannot reduce capacity below current utilization");
            
        TotalCapacity = newCapacity;
    }
    
    public void AssignSensor(string sensorId)
    {
        SensorId = sensorId;
    }
    
    public void UpdateStatus(EInventoryStatus newStatus)
    {
        Status = newStatus;
    }
    
    public void AddProduct(ProductIdentifier productId, int quantity, DateTime expirationDate)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive");
            
        if (UsedCapacity + quantity > TotalCapacity)
            throw new InvalidOperationException("Insufficient capacity in storage box");
            
        var existingItem = _boxItems.FirstOrDefault(item => item.ProductId == productId);
        
        if (existingItem != null)
        {
            existingItem.UpdateQuantity(existingItem.Quantity + quantity);
        }
        else
        {
            _boxItems.Add(new BoxItem(productId, quantity, expirationDate));
        }
    }
    
    public void RemoveProduct(ProductIdentifier productId, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be positive");
            
        var existingItem = _boxItems.FirstOrDefault(item => item.ProductId == productId);
        
        if (existingItem == null)
            throw new InvalidOperationException("Product not found in storage box");
            
        if (existingItem.Quantity < quantity)
            throw new InvalidOperationException("Insufficient quantity in storage box");
            
        if (existingItem.Quantity == quantity)
        {
            _boxItems.Remove(existingItem);
        }
        else
        {
            existingItem.UpdateQuantity(existingItem.Quantity - quantity);
        }
    }
    
    public bool CanAccommodateProduct(BoxType productBoxType, int quantity)
    {
        return Type == productBoxType && UsedCapacity + quantity <= TotalCapacity;
    }
    
    public IEnumerable<BoxItem> GetExpiringProducts(int daysThreshold = 3)
    {
        var thresholdDate = DateTime.UtcNow.AddDays(daysThreshold);
        return _boxItems.Where(item => item.ExpirationDate <= thresholdDate);
    }
}
    