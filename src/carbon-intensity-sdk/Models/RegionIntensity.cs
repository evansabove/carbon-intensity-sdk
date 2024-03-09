using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record RegionIntensity
{
    [JsonPropertyName("regionid")]
    public required int RegionId { get; init; }

    [JsonPropertyName("dnoregion")]
    public required string DnoRegion { get; init; }

    [JsonPropertyName("shortname")]
    public required string ShortName { get; init; }

    [JsonPropertyName("intensity")]
    public required CarbonIntensity Intensity { get; init; }

    [JsonPropertyName("generationmix")]
    public required GenerationMix[] GenerationMix { get; init; }
}