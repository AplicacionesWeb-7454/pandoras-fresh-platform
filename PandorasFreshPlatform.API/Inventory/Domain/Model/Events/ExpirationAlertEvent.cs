using PandorasFreshPlatform.API.Shared.Domain.Model.Events;

namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Events;

public class ExpirationAlertEvent(int productInstanceId, string productName, DateTime expirationDate, int daysUntilExpiration) : IEvent
{
    public int ProductInstanceId { get; } = productInstanceId;
    public string ProductName { get; } = productName;
    public DateTime ExpirationDate { get; } = expirationDate;
    public int DaysUntilExpiration { get; } = daysUntilExpiration;
}