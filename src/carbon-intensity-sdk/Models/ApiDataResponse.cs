using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record ApiDataResponse<T>
{
    [JsonPropertyName("data")]
    public required T Data { get; init; }
}