namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST;

using Microsoft.AspNetCore.Mvc;
using SensorMonitoring.Application.Internal.CommandServices;
using SensorMonitoring.Domain.Model.Commands;
using SensorMonitoring.Domain.Repositories;
using SensorMonitoring.Interfaces.REST.Transform;
using SensorMonitoring.Interfaces.REST.Resources;


[ApiController]
[Route("api/[controller]")]
public class LinksController : ControllerBase
{
    private readonly ILinkRepository _repository;
    private readonly LinkSensorCommandService _commandService;

    public LinksController(ILinkRepository repository, LinkSensorCommandService commandService)
    {
        _repository = repository;
        _commandService = commandService;
    }

    /// <summary>
    /// Vincula un sensor a una zona.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> LinkSensor([FromBody] LinkSensorCommand command)
    {
        await _commandService.ExecuteAsync(command);
        return CreatedAtAction(nameof(GetBySensorId), new { sensorId = command.SensorId }, command);
    }

    /// <summary>
    /// Obtiene la vinculación de un sensor por su ID.
    /// </summary>
    [HttpGet("{sensorId}")]
    public async Task<ActionResult<IEnumerable<LinkResource>>> GetBySensorId(string sensorId)
    {
        var links = await _repository.GetBySensorIdAsync(sensorId);
        return Ok(links.Select(LinkMapper.ToResource));
    }
}
