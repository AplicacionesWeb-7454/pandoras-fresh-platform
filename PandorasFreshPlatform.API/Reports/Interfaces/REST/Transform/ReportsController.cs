using CatchUpPlatform.API.Reports.Application.Internal.CommandServices.Handlers;
using pandoraFr.API.Reports.Application.Internal.CommandServices.Handlers;
using pandoraFr.API.Reports.Application.Internal.QueryServices.Handlers;
using Microsoft.AspNetCore.Mvc;
using pandoraFr.API.Reports.Interfaces.REST.Transform;
using pandoraFr.API.Reports.Interfaces.REST.Resources;
using pandoraFr.API.Reports.Application.Internal.CommandServices;
using pandoraFr.API.Reports.Application.Internal.QueryServices;


using pandoraFr.API.Reports.Domain.Model;

namespace pandoraFr.API.Reports.Interfaces.REST.Transform;

[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly GenerateInventoryReportCommandHandler _invHandler;
    private readonly GenerateLossesReportCommandHandler _lossHandler;
    private readonly ExportReportCommandHandler _exportHandler;
    private readonly ShareReportCommandHandler _shareHandler;
    private readonly GetDashboardMetricsQueryHandler _dashboardHandler;

    public ReportsController(
        GenerateInventoryReportCommandHandler invHandler,
        GenerateLossesReportCommandHandler lossHandler,
        ExportReportCommandHandler exportHandler,
        ShareReportCommandHandler shareHandler,
        GetDashboardMetricsQueryHandler dashboardHandler)
    {
        _invHandler = invHandler;
        _lossHandler = lossHandler;
        _exportHandler = exportHandler;
        _shareHandler = shareHandler;
        _dashboardHandler = dashboardHandler;
    }

    [HttpPost("inventory")]
    public async Task<ActionResult<ReportResource>> GenerateInventory([FromBody] InventoryReportRequest req)
    {
        var id = await _invHandler.HandleAsync(new GenerateInventoryReportCommand(req.From, req.To));
        return Ok(new ReportResource(id, "Reporte de inventario", ReportType.Inventory.ToString(), DateTime.UtcNow));
    }

    [HttpPost("losses")]
    public async Task<ActionResult<ReportResource>> GenerateLosses([FromBody] LossesReportRequest req)
    {
        var id = await _lossHandler.HandleAsync(new GenerateLossesReportCommand(req.From, req.To, req.ProductType));
        return Ok(new ReportResource(id, "Reporte de mermas", ReportType.Losses.ToString(), DateTime.UtcNow));
    }

    [HttpGet("{id:guid}/export")]
    public async Task<IActionResult> Export([FromRoute] Guid id, [FromQuery] ReportFormat format = ReportFormat.Pdf)
    {
        var (fileName, bytes, mime) = await _exportHandler.HandleAsync(new ExportReportCommand(id, format));
        return File(bytes, mime, fileName);
    }

    [HttpGet("dashboard")]
    public async Task<ActionResult<DashboardResource>> Dashboard([FromQuery] DateTime? at)
    {
        var (totalInv, totalLossUnits, totalLossCost, alerts) =
            await _dashboardHandler.HandleAsync(new GetDashboardMetricsQuery(at));

        return Ok(new DashboardResource(totalInv, totalLossUnits, totalLossCost, alerts));
    }

    [HttpPost("{id:guid}/share")]
    public async Task<IActionResult> Share([FromRoute] Guid id, [FromBody] ReportShareRequest req)
    {
        await _shareHandler.HandleAsync(new ShareReportCommand(id, req.Email, req.Message));
        return Accepted();
    }
}
