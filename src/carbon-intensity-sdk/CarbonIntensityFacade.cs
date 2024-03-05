using CarbonIntensitySdk.Exceptions;
using CarbonIntensitySdk.Models;
using Flurl.Http;

namespace CarbonIntensitySdk;

public class CarbonIntensityFacade
{
    public static Uri BaseUri => new("https://api.carbonintensity.org.uk/");

    public async Task<TResponse> CallApi<TResponse>(string path)
    {
        try
        {
            var response = await $"{BaseUri}{path}".GetJsonAsync<TResponse>();

            return response;
        }
        catch (FlurlHttpException e)
        {
            var error = await e.GetResponseJsonAsync<ErrorResponse>();

            throw new ApiRequestFailedException(
                $"API request to path \"{path}\" failed with error code {error.Error.Code} and message \"{error.Error.Message}\"");
        }
    }
}