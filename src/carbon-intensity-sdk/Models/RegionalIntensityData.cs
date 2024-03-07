using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record RegionalIntensityData : TimeBoxedData
{
    [JsonPropertyName("regions")]
    public required RegionIntensity[] Regions { get; init; }
}