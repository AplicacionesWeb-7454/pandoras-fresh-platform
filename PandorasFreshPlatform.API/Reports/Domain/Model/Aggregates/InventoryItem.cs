

namespace PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates
{
    /// <summary>
    /// Aggregate representing an inventory item snapshot used for reporting.
    /// </summary>
    public record InventoryItem
    {
        public int Id { get; init; }
        public string Sku { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public int Quantity { get; init; }
        public decimal Cost { get; init; }
        public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    }

}