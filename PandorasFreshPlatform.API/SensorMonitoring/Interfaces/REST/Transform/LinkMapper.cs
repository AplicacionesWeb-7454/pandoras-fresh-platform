namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST.Transform;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Interfaces.REST.Resources;


public static class LinkMapper
{
    public static LinkResource ToResource(Link link) =>
        new(link.SensorId, link.Zone, link.Code, link.Notes);
}
