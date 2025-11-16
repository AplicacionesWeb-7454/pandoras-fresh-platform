namespace pandoraFr.API.Reports.Interfaces.REST.Transform;

public record ReportShareRequest(Guid ReportId, string Email, string? Message);