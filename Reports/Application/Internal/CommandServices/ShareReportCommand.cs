namespace pandoraFr.API.Reports.Application.Internal.CommandServices;

public record ShareReportCommand(Guid ReportId, string Email, string? Message);