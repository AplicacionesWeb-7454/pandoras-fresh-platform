using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;

public partial class Inventory : IEntityWithCreatedUpdatedDate
{
    public int Id { get; private set; }
    public string ClientId { get; private set; }
    public string Name { get; private set; }
    public decimal OverallUtilization => CalculateOverallUtilization();
    public int TotalBoxes => StorageBoxes.Count;
    public int TotalProducts => StorageBoxes.Sum(box => box.BoxItems.Count);
    
    private readonly List<StorageBox> _storageBoxes = new();
    public IReadOnlyCollection<StorageBox> StorageBoxes => _storageBoxes.AsReadOnly();
    
    [Column("CreatedAt")] 
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] 
    public DateTimeOffset? UpdatedDate { get; set; }
    
    private Inventory()
    {
        ClientId = string.Empty;
        Name = string.Empty;
    }
    
    public Inventory(string clientId, string name)
    {
        if (string.IsNullOrWhiteSpace(clientId))
            throw new ArgumentException("Client ID is required");
            
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Inventory name is required");
        
        ClientId = clientId.Trim();
        Name = name.Trim();
    }
    
    public void AddStorageBox(StorageBox storageBox)
    {
        if (_storageBoxes.Any(box => box.Id == storageBox.Id))
            throw new InvalidOperationException("Storage box already exists in inventory");
            
        _storageBoxes.Add(storageBox);
    }
    
    public void RemoveStorageBox(int boxId)
    {
        var box = _storageBoxes.FirstOrDefault(b => b.Id == boxId);
        if (box != null)
        {
            _storageBoxes.Remove(box);
        }
    }
    
    public IEnumerable<StorageBox> GetBoxesByType(BoxType boxType)
    {
        return _storageBoxes.Where(box => box.Type == boxType);
    }
    
    public IEnumerable<StorageBox> GetBoxesWithHighUtilization(decimal threshold = 0.8m)
    {
        return _storageBoxes.Where(box => box.UtilizationRate >= threshold);
    }
    
    public IEnumerable<BoxItem> GetAllExpiringProducts(int daysThreshold = 3)
    {
        return _storageBoxes.SelectMany(box => box.GetExpiringProducts(daysThreshold));
    }
    
    private decimal CalculateOverallUtilization()
    {
        if (_storageBoxes.Count == 0)
            return 0;
            
        var totalCapacity = _storageBoxes.Sum(box => box.TotalCapacity);
        var totalUsed = _storageBoxes.Sum(box => box.UsedCapacity);
        
        return totalCapacity > 0 ? (decimal)totalUsed / totalCapacity : 0;
    }
}