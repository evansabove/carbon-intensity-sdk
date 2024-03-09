using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record AllRegionData : TimeBoxedData
{
    [JsonPropertyName("regions")]
    public required AllRegionRegionData[] Regions { get; init; }
}