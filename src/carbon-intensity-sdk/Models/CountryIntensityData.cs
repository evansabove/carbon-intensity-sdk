using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record CountryIntensityData
{
    [JsonPropertyName("regionid")]
    public required int RegionId { get; init; }

    [JsonPropertyName("dnoregion")]
    public required string DnoRegion { get; init; }

    [JsonPropertyName("shortname")]
    public required string ShortName { get; init; }

    [JsonPropertyName("data")]
    public required CountryIntensity[] Intensities { get; init; }

    //bit weird that we have both of these
    public CountryIntensity Intensity => Intensities.Single();
}