using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record IntensityResponse
{
    [JsonPropertyName("data")]
    public required IntensityData[] Data { get; init; }
}