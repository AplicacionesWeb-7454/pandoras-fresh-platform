namespace PandorasFreshPlatform.API.SensorMonitoring.Application.Internal.CommandServices;

using SensorMonitoring.Domain.Model.Commands;
using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Repositories;

public class LinkSensorCommandService
{
    private readonly ILinkRepository _repository;

    public LinkSensorCommandService(ILinkRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(LinkSensorCommand command)
    {
        var link = new Link
        {
            SensorId = command.SensorId,
            Zone = command.Zone,
            Code = command.Code,
            Notes = command.Notes
        };

        await _repository.AddAsync(link);
    }
}
