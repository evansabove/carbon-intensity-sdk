using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

//weird that this contains a base property of type 'CountryIntensity' when this is about a specific postcode.
//wants to be called RegionalIntensity but there's a clash.
public record PostcodeIntensityData : CountryIntensityData
{
    [JsonPropertyName("postcode")]
    public required string Postcode { get; init; }
}