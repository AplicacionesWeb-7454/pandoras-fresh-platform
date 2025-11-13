namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST.Transform;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Interfaces.REST.Resources;

public static class ReadingMapper
{
    public static ReadingResource ToResource(Reading r) =>
        new(r.Timestamp, r.Temperature, r.Humidity, r.Wind);
}
