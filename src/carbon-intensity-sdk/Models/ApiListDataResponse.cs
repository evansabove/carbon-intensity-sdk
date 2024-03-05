using System.Text.Json.Serialization;
using CarbonIntensitySdk.Exceptions;

namespace CarbonIntensitySdk.Models;

public record ApiListDataResponse<T>
{
    [JsonPropertyName("data")]
    public required T[] Data { get; init; }

    //Consider extracting this
    public void AssertHasSingleDataEntry()
    {
        if (!Data.Any())
        {
            throw new UnexpectedApiResponseException("Expected single result but none were found");
        }

        if (Data.Length > 1)
        {
            throw new UnexpectedApiResponseException("Only 1 result expected but multiple were found");
        }
    }
}