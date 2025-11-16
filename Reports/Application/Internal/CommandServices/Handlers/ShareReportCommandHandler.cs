using pandoraFr.API.Reports.Application.Internal.CommandServices;
using pandoraFr.API.Reports.Domain.Repositories;
using pandoraFr.API.Reports.Domain.Services;
using pandoraFr.API.Reports.Domain.Model;

namespace CatchUpPlatform.API.Reports.Application.Internal.CommandServices.Handlers;

public class ShareReportCommandHandler
{
    private readonly IReportWriteRepository _reportWrite;
    private readonly IReportExportService _exporter;
    private readonly IEmailSenderService _email;

    public ShareReportCommandHandler(
        IReportWriteRepository reportWrite,
        IReportExportService exporter,
        IEmailSenderService email)
    {
        _reportWrite = reportWrite;
        _exporter = exporter;
        _email = email;
    }

    public async Task HandleAsync(ShareReportCommand cmd)
    {
        var report = await _reportWrite.GetAsync(cmd.ReportId)
                     ?? throw new InvalidOperationException("Reporte no encontrado");

        var (fileName, bytes, mime) = await _exporter.ExportAsync(report, ReportFormat.Pdf);
        await _email.SendAsync(cmd.Email, report.Title, cmd.Message ?? "Reporte generado", fileName, bytes, mime);
    }
}