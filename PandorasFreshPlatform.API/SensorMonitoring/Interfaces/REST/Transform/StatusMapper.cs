namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST.Transform;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Interfaces.REST.Resources;

public static class StatusMapper
{
    public static StatusResource ToResource(Status status) => new(status.Id, status.Name);
}
