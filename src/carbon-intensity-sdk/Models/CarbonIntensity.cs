using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models
{
    public record CarbonIntensity
    {
        [JsonPropertyName("forecast")]
        public required int Forecast { get; init; }

        [JsonPropertyName("actual")]
        public required int? Actual { get; init; }

        [JsonPropertyName("index")]
        public required string Index { get; init; }
    }
}
