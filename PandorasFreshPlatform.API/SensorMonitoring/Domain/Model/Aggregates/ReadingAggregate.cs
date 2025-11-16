namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.Aggregates;

using SensorMonitoring.Domain.Model.Entities;


public class ReadingAggregate
{
    public Sensor Sensor { get; }
    public IEnumerable<Reading> Readings { get; }

    public ReadingAggregate(Sensor sensor, IEnumerable<Reading> readings)
    {
        Sensor = sensor;
        Readings = readings.OrderByDescending(r => r.Timestamp);
    }

    public Reading? Latest => Readings.FirstOrDefault();
}
