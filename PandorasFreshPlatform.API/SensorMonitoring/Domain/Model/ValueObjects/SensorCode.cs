namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.ValueObjects;


public record SensorCode
{
    public string Value { get; init; }

    public SensorCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
            throw new ArgumentException("Sensor code must be at least 5 characters.");
        
        Value = value;
    }

    public override string ToString() => Value;
}
