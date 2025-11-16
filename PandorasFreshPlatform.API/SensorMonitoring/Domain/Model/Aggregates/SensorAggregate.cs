namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.Aggregates;

using SensorMonitoring.Domain.Model.Entities;
using SensorMonitoring.Domain.Model.ValueObjects;

public class SensorAggregate
{
    public Sensor Sensor { get; }
    public SensorStatus Status { get; }
    public SensorLocation Location { get; }
    public SensorCode Code { get; }

    public SensorAggregate(Sensor sensor)
    {
        Sensor = sensor;
        Status = new SensorStatus(sensor.Status);
        Location = new SensorLocation(sensor.Location.Split(',')[0], sensor.Location.Split(',')[1]);
        Code = new SensorCode(sensor.Id);
    }
}
