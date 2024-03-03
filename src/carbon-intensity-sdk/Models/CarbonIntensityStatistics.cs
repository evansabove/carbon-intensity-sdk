using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record CarbonIntensityStatistics
{
    [JsonPropertyName("max")]
    public required int Max { get; init; }

    [JsonPropertyName("average")]
    public required int Average { get; init; }

    [JsonPropertyName("min")]
    public required int Min { get; init; }

    [JsonPropertyName("index")]
    public required string Index { get; init; }
}