using pandoraFr.API.Reports.Domain.Model;
using pandoraFr.API.Reports.Domain.Services;

namespace pandoraFr.API.Reports.Domain.Services.Implementations;

public class ReportExportService : IReportExportService
{
    public async Task<(string FileName, byte[] Bytes, string Mime)> ExportAsync(Report report, ReportFormat format)
    {
        // Simulación de exportación
        var fileName = $"{report.Title}_{DateTime.UtcNow:yyyyMMdd}.pdf";
        var bytes = new byte[] { 1, 2, 3 }; // contenido simulado
        var mime = "application/pdf";

        return await Task.FromResult((fileName, bytes, mime));
    }
}