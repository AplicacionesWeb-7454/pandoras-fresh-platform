namespace PandorasFreshPlatform.API.SensorMonitoring.Domain.Model.ValueObjects;

public record SensorStatus
{
    public string Value { get; }

    private static readonly HashSet<string> Allowed = new() { "Active", "Inactive", "Error" };

    public SensorStatus(string value)
    {
        if (!Allowed.Contains(value))
            throw new ArgumentException($"Invalid status: {value}");

        Value = value;
    }

    public override string ToString() => Value;
}
