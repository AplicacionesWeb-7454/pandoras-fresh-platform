namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST.Transform;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Interfaces.REST.Resources;

public static class ZoneMapper
{
    public static ZoneResource ToResource(Zone zone) => new(zone.Id, zone.Name);
}
