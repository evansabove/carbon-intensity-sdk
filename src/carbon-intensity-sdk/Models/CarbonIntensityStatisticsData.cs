using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record CarbonIntensityStatisticsData : TimeBoxedData
{
    [JsonPropertyName("intensity")]
    public required CarbonIntensityStatistics Intensity { get; init; }
}