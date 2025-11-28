using System;

/// <summary>
/// DTO exposed via REST representing a report.
/// </summary>
namespace PandorasFreshPlatform.API.Reports.Interfaces.REST.Resources
{
    public class ReportResource
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime GeneratedAt { get; set; }
    }
}