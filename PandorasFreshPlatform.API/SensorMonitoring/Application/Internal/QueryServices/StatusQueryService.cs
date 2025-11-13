namespace PandorasFreshPlatform.API.SensorMonitoring.Application.Internal.QueryServices;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;

public class StatusQueryService
{
    private readonly IStatusRepository _repository;

    public StatusQueryService(IStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Status>> GetAllAsync() => await _repository.GetAllAsync();
}
