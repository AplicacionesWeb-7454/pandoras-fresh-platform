namespace pandoraFr.API.Reports.Interfaces.REST.Resources;

public record ReportResource(Guid Id, string Title, string Type, DateTime GeneratedAt);