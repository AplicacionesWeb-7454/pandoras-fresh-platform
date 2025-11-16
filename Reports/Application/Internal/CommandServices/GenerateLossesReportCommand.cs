namespace pandoraFr.API.Reports.Application.Internal.CommandServices;

public record GenerateLossesReportCommand(DateTime From, DateTime To, string? ProductType);