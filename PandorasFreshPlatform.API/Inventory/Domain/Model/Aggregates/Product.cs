using PandorasFreshPlatform.API.Inventory.Domain.Model.Entities;
using PandorasFreshPlatform.API.Inventory.Domain.Model.ValueObjects;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Aggregates;


public partial class Product
{
    public ProductIdentifier Id { get; private set; }
    public string Name { get; private set; }
    public string Category { get; private set; }
    public int TotalQuantity { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public decimal? OptimalTemperature { get; private set; }
    public decimal? OptimalHumidity { get; private set; }
    public string? Barcode { get; private set; }
    public int CategoryId { get; private set; }
    
    // Computed properties
    public int DaysUntilExpiration => (int)(ExpirationDate - DateTime.UtcNow).TotalDays;
    public EProductStatus Status => CalculateStatus();
    
    private Product() 
    {
        // For EF
        Id = new ProductIdentifier();
        Name = string.Empty;
        Category = string.Empty;
    }
    
    public Product(string name, string category, DateTime expirationDate, 
                  decimal? optimalTemperature = null, decimal? optimalHumidity = null, 
                  string? barcode = null, int categoryId = 0)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required");
            
        if (expirationDate <= DateTime.UtcNow)
            throw new ArgumentException("Expiration date must be in the future");
        
        Id = new ProductIdentifier();
        Name = name.Trim();
        Category = category.Trim();
        ExpirationDate = expirationDate;
        OptimalTemperature = optimalTemperature;
        OptimalHumidity = optimalHumidity;
        Barcode = barcode;
        CategoryId = categoryId;
        TotalQuantity = 0;
    }
    
    public void UpdateDetails(string name, string category, decimal? optimalTemperature, 
                            decimal? optimalHumidity, string? barcode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required");
            
        Name = name.Trim();
        Category = category.Trim();
        OptimalTemperature = optimalTemperature;
        OptimalHumidity = optimalHumidity;
        Barcode = barcode;
    }
    
    public void UpdateExpirationDate(DateTime newExpirationDate)
    {
        if (newExpirationDate <= DateTime.UtcNow)
            throw new ArgumentException("Expiration date must be in the future");
            
        ExpirationDate = newExpirationDate;
    }
    
    public void UpdateTotalQuantity(int newQuantity)
    {
        if (newQuantity < 0)
            throw new ArgumentException("Quantity cannot be negative");
            
        TotalQuantity = newQuantity;
    }
    
    public bool IsEnvironmentallyCompliant(decimal currentTemperature, decimal currentHumidity)
    {
        if (!OptimalTemperature.HasValue && !OptimalHumidity.HasValue)
            return true;
            
        var range = new EnvironmentalRange(
            OptimalTemperature, OptimalTemperature,
            OptimalHumidity, OptimalHumidity
        );
        
        return range.IsWithinRange(currentTemperature, currentHumidity);
    }
    
    private EProductStatus CalculateStatus()
    {
        var daysUntilExpiration = DaysUntilExpiration;
        
        if (daysUntilExpiration < 0)
            return EProductStatus.Expired;
        else if (daysUntilExpiration <= 3)
            return EProductStatus.ExpiringSoon;
        else
            return EProductStatus.Fresh;
    }
}