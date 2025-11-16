using pandoraFr.API.Reports.Domain.Model;

namespace pandoraFr.API.Reports.Interfaces.REST.Transform;

public record ReportExportRequest(Guid ReportId, ReportFormat Format);