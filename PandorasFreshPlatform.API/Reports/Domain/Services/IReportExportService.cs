using pandoraFr.API.Reports.Domain.Model;

namespace pandoraFr.API.Reports.Domain.Services;

public interface IReportExportService
{
    Task<(string FileName, byte[] Bytes, string Mime)> ExportAsync(Report report, ReportFormat format);
}