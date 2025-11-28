
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PandorasFreshPlatform.API.Reports.Application.Internal.CommandServices;
using PandorasFreshPlatform.API.Reports.Application.Internal.QueryServices;
using PandorasFreshPlatform.API.Reports.Domain.Model.Commands;
using PandorasFreshPlatform.API.Reports.Domain.Model.Queries;
using PandorasFreshPlatform.API.Reports.Interfaces.REST.Transform;
using PandorasFreshPlatform.API.Resources; // SharedResource marker

namespace PandorasFreshPlatform.API.Reports.Interfaces.REST
{
    /// <summary>
    /// REST controller exposing reports endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly GenerateInventoryReportCommandService _commandService;
        private readonly GetDashboardMetricsQueryService _queryService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ReportsController(
            GenerateInventoryReportCommandService commandService,
            GetDashboardMetricsQueryService queryService,
            IStringLocalizer<SharedResource> localizer)
        {
            _commandService = commandService;
            _queryService = queryService;
            _localizer = localizer;
        }

        /// <summary>Generates a report based on the provided command.</summary>
        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] GenerateReportCommand command)
        {
            var report = await _commandService.HandleAsync(command);
            var message = _localizer["ReportGeneratedSuccessfully"];
            return Ok(new { message, report = ReportResourceFromEntityAssembler.ToResource(report) });
        }

        /// <summary>Returns dashboard metrics within a date range.</summary>
        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var result = await _queryService.HandleAsync(new GetDashboardMetricsQuery { From = from, To = to });
            return Ok(result);
        }
    }
}
