using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates
{
    /// <summary>
    /// Aggregate representing a report snapshot used for reporting.
    /// </summary>
    public class Report
    {
        public int Id { get; init; }
        public string Title { get; init; } = string.Empty;
        public DateTime GeneratedAt { get; init; } = DateTime.UtcNow;
        public string Type { get; init; } = "Inventory";

        /// <summary>
        /// Dynamic payload for API responses. Not persisted in the database.
        /// </summary>
        [NotMapped]
        public object? Data { get; init; }
    }
}