using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record GenerationMix
{
    [JsonPropertyName("fuel")]
    public required string Fuel { get; init; }

    [JsonPropertyName("perc")]
    public required double Percentage { get; init; }
}