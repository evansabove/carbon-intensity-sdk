using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record ApiListDataResponse<T>
{
    [JsonPropertyName("data")]
    public required T[] Data { get; init; }
}