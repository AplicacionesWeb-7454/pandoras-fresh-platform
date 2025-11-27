using pandoraFr.API.Reports.Domain.Model;

namespace pandoraFr.API.Reports.Application.Internal.CommandServices;

public record ExportReportCommand(Guid ReportId, ReportFormat Format);