using CarbonIntensitySdk.Models;
using Flurl.Http;

namespace CarbonIntensitySdk;

public class CarbonIntensityFacade
{
    public static Uri BaseUri => new("https://api.carbonintensity.org.uk/");

    public async Task<IntensityData[]> CallApi(string path)
    {
        var response = await $"{BaseUri}{path}".GetJsonAsync<IntensityResponse>();

        return response.Data;
    }
}