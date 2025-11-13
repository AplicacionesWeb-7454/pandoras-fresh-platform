namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST;

using Microsoft.AspNetCore.Mvc;
using SensorMonitoring.Application.Internal.QueryServices;
using SensorMonitoring.Interfaces.REST.Transform;
using SensorMonitoring.Interfaces.REST.Resources;


[ApiController]
[Route("api/[controller]")]
public class ZonesController : ControllerBase
{
    private readonly ZoneQueryService _service;

    public ZonesController(ZoneQueryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Lista todas las zonas disponibles.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ZoneResource>>> GetAll()
    {
        var zones = await _service.GetAllAsync();
        return Ok(zones.Select(ZoneMapper.ToResource));
    }
}
