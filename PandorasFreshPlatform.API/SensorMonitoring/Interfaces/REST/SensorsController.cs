namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST;

using Microsoft.AspNetCore.Mvc;
using SensorMonitoring.Application.Internal.QueryServices;
using SensorMonitoring.Interfaces.REST.Transform;
using SensorMonitoring.Interfaces.REST.Resources;

[ApiController]
[Route("api/[controller]")]
public class SensorsController : ControllerBase
{
    private readonly SensorQueryService _service;

    public SensorsController(SensorQueryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene todos los sensores registrados.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SensorResource>>> GetAll()
    {
        var sensors = await _service.GetAllAsync();
        return Ok(sensors.Select(SensorMapper.ToResource));
    }

    /// <summary>
    /// Obtiene un sensor por su ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<SensorResource>> GetById(string id)
    {
        var sensor = await _service.GetByIdAsync(id);
        if (sensor is null) return NotFound();
        return Ok(SensorMapper.ToResource(sensor));
    }
}
