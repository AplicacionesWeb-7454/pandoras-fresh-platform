using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;

public class BoxItem : IEntityWithCreatedUpdatedDate
{
    // Private constructor for EF
    private BoxItem() { }
    
    public BoxItem(ProductIdentifier productId, int quantity, DateTime expirationDate)
    {
        ProductId = productId;
        Quantity = quantity;
        ExpirationDate = expirationDate;
        AddedDate = DateTime.UtcNow;
        LastChecked = DateTime.UtcNow;
    }
    
    public int Id { get; private set; }
    public ProductIdentifier ProductId { get; private set; }
    public int Quantity { get; private set; }
    public DateTime AddedDate { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public DateTime LastChecked { get; private set; }
    
    [Column("CreatedAt")] 
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] 
    public DateTimeOffset? UpdatedDate { get; set; }
    
    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity < 0)
            throw new ArgumentException("Quantity cannot be negative");
            
        Quantity = newQuantity;
        LastChecked = DateTime.UtcNow;
    }
    
    public void UpdateExpirationDate(DateTime newExpirationDate)
    {
        if (newExpirationDate <= DateTime.UtcNow)
            throw new ArgumentException("Expiration date must be in the future");
            
        ExpirationDate = newExpirationDate;
        LastChecked = DateTime.UtcNow;
    }
    
    public EProductStatus GetStatus()
    {
        var daysUntilExpiration = (ExpirationDate - DateTime.UtcNow).Days;
        
        if (daysUntilExpiration < 0)
            return EProductStatus.Expired;
        else if (daysUntilExpiration <= 3)
            return EProductStatus.ExpiringSoon;
        else
            return EProductStatus.Fresh;
    }
}