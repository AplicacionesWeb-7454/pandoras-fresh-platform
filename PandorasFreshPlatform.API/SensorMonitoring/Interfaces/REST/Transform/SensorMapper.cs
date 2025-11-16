namespace PandorasFreshPlatform.API.SensorMonitoring.Interfaces.REST.Transform;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Interfaces.REST.Resources;


public static class SensorMapper
{
    public static SensorResource ToResource(Sensor sensor) =>
        new(sensor.Id, sensor.Name, sensor.Zone, sensor.Location, sensor.Status, sensor.LastReading);
}
