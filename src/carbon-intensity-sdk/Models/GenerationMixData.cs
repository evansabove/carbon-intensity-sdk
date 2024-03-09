using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record GenerationMixData : TimeBoxedData
{
    [JsonPropertyName("generationmix")]
    public required GenerationMix[] GenerationMix { get; init; }

    public double? GasPercentage => GenerationMix.SingleOrDefault(x => x.Fuel == "gas")?.Percentage;
    public double? CoalPercentage => GenerationMix.SingleOrDefault(x => x.Fuel == "coal")?.Percentage;
    public double? NuclearPercentage => GenerationMix.SingleOrDefault(x => x.Fuel == "nuclear")?.Percentage;
    public double? WindPercentage => GenerationMix.SingleOrDefault(x => x.Fuel == "wind")?.Percentage;
    public double? SolarPercentage => GenerationMix.SingleOrDefault(x => x.Fuel == "solar")?.Percentage;
    public double? HydroPercentage => GenerationMix.SingleOrDefault(x => x.Fuel == "hydro")?.Percentage;
    public double? OtherPercentage => GenerationMix.SingleOrDefault(x => x.Fuel == "other")?.Percentage;
    public double? ImportsPercentage => GenerationMix.SingleOrDefault(x => x.Fuel == "imports")?.Percentage;
    public double? BiomassPercentage => GenerationMix.SingleOrDefault(x => x.Fuel == "biomass")?.Percentage;
}