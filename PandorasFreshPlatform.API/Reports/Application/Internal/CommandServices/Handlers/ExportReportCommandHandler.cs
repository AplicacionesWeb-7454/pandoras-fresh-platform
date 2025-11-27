using pandoraFr.API.Reports.Application.Internal.CommandServices;
using pandoraFr.API.Reports.Domain.Services;
using pandoraFr.API.Reports.Domain.Repositories;

namespace pandoraFr.API.Reports.Application.Internal.CommandServices.Handlers;

public class ExportReportCommandHandler
{
    private readonly IReportWriteRepository _reportWrite;
    private readonly IReportExportService _exporter;

    public ExportReportCommandHandler(IReportWriteRepository reportWrite, IReportExportService exporter)
    {
        _reportWrite = reportWrite;
        _exporter = exporter;
    }

    public async Task<(string FileName, byte[] Bytes, string Mime)> HandleAsync(ExportReportCommand cmd)
    {
        var report = await _reportWrite.GetAsync(cmd.ReportId)
                     ?? throw new InvalidOperationException("Reporte no encontrado");

        var result = await _exporter.ExportAsync(report, cmd.Format);
        return result;
    }
}