using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record IntensityData
{
    [JsonPropertyName("from")]
    public required DateTime FromUtc { get; init; }

    [JsonPropertyName("to")]
    public required DateTime ToUtc { get; init; }

    [JsonPropertyName("intensity")]
    public required Intensity Intensity { get; init; }   
}