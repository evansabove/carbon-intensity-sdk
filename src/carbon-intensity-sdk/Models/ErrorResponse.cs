using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models
{
    public record ErrorResponse
    {
        [JsonPropertyName("error")]
        public required Error Error { get; set; }
    }

    public record Error
    {
        [JsonPropertyName("code")]
        public required string Code { get; init; }

        [JsonPropertyName("message")]
        public required string Message { get; init; }
    }
}
