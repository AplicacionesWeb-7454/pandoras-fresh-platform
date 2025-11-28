using System.ComponentModel.DataAnnotations;


namespace PandorasFreshPlatform.API.Reports.Domain.Model.Commands
{
    /// <summary>
    /// Command to generate a report (Inventory or Losses).
    /// </summary>
    public class GenerateReportCommand
    {
        /// <summary>Type of report: 'Inventory' or 'Losses'.</summary>
        [Required]
        [RegularExpression("Inventory|Losses")]
        public string ReportType { get; set; } = "Inventory";
    }
}