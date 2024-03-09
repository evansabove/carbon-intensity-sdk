using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record TimeBoxedData
{
    [JsonPropertyName("from")]
    public required DateTime FromUtc { get; init; }

    [JsonPropertyName("to")]
    public required DateTime ToUtc { get; init; }
}