namespace PandorasFreshPlatform.API.SensorMonitoring.Application.Internal.QueryServices;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;

public class ZoneQueryService
{
    private readonly IZoneRepository _repository;

    public ZoneQueryService(IZoneRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Zone>> GetAllAsync() => await _repository.GetAllAsync();
}
