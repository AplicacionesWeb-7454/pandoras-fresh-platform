


namespace PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates
{
    /// <summary>
    /// Aggregate representing a loss record snapshot used for reporting.
    /// </summary>
    public class LossRecord
    {
        public int Id { get; init; }
        
        public string Reason { get; init; } = string.Empty;
        public decimal Cost { get; init; }
        public DateTime Date { get; init; }
    }
}