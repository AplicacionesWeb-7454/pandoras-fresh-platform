namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST;

using Microsoft.AspNetCore.Mvc;
using SensorMonitoring.Application.Internal.QueryServices;
using SensorMonitoring.Interfaces.REST.Transform;
using SensorMonitoring.Interfaces.REST.Resources;

[ApiController]
[Route("api/[controller]")]
public class ReadingsController : ControllerBase
{
    private readonly ReadingQueryService _service;

    public ReadingsController(ReadingQueryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene las lecturas de un sensor por su ID.
    /// </summary>
    [HttpGet("{sensorId}")]
    public async Task<ActionResult<IEnumerable<ReadingResource>>> GetBySensorId(string sensorId)
    {
        var readings = await _service.GetBySensorIdAsync(sensorId);
        return Ok(readings.Select(ReadingMapper.ToResource));
    }
}
