using System.ComponentModel.DataAnnotations;


namespace PandorasFreshPlatform.API.Reports.Domain.Model.Queries
{
    /// <summary>
    /// Query to retrieve aggregated metrics for the dashboard.
    /// </summary>
    public class GetDashboardMetricsQuery
    {
        [Required] public DateTime From { get; set; }
        [Required] public DateTime To { get; set; }
    }
}