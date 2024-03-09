using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record CarbonIntensityData : TimeBoxedData
{
    [JsonPropertyName("intensity")]
    public required CarbonIntensity Intensity { get; init; }   
}