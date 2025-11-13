namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST;

using Microsoft.AspNetCore.Mvc;
using SensorMonitoring.Application.Internal.QueryServices;
using SensorMonitoring.Interfaces.REST.Transform;
using SensorMonitoring.Interfaces.REST.Resources;


[ApiController]
[Route("api/[controller]")]
public class StatusesController : ControllerBase
{
    private readonly StatusQueryService _service;

    public StatusesController(StatusQueryService service)
    {
        _service = service;
    }

    /// <summary>
    /// Lista todos los estados posibles de sensores.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusResource>>> GetAll()
    {
        var statuses = await _service.GetAllAsync();
        return Ok(statuses.Select(StatusMapper.ToResource));
    }
}
