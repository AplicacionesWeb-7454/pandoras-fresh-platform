namespace pandoraFr.API.Reports.Interfaces.REST.Transform;

public record LossesReportRequest(DateTime From, DateTime To, string? ProductType);