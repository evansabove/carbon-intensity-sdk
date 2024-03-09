using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record RegionIntensityData
{
    [JsonPropertyName("regionid")]
    public required int RegionId { get; init; }

    [JsonPropertyName("dnoregion")]
    public string? DnoRegion { get; init; }

    [JsonPropertyName("shortname")]
    public required string ShortName { get; init; }

    [JsonPropertyName("data")]
    public required RegionIntensity[] Intensities { get; init; }
}