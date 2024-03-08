using CarbonIntensitySdk.Enums;
using CarbonIntensitySdk.Extensions;
using CarbonIntensitySdk.Models;

namespace CarbonIntensitySdk
{
    public partial class CarbonIntensityClient
    {
        /// <summary>
        /// Get Carbon Intensity data for current half hour for GB regions
        /// </summary>
        /// <returns><see cref="T:RegionalIntensityData"/></returns>
        public async Task<RegionalIntensityData[]> GetRegionalData()
        {
            var data = await facade.CallApi<ApiListDataResponse<RegionalIntensityData>>("regional");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data for current half hour for the specified country
        /// </summary>
        /// <param name="country"></param>
        /// <returns><see cref="T:CountryIntensityData"/></returns>
        public async Task<CountryIntensityData> GetCountryData(Country country)
        {
            var region = country switch
            {
                Country.England => Region.England,
                Country.Scotland => Region.Scotland,
                Country.Wales => Region.Wales,
                _ => throw new ArgumentOutOfRangeException(nameof(country), country, null)
            };

            return await GetRegionData(region);
        }

        public async Task<PostcodeIntensityData> GetPostcodeData(string postcode)
        {
            var data = await facade.CallApi<ApiListDataResponse<PostcodeIntensityData>>($"regional/postcode/{postcode}");

            data.Data.AssertHasSingleEntry();
            data.Data[0].Intensities.AssertHasSingleEntry();

            return data.Data[0];
        }

        public async Task<CountryIntensityData> GetRegionData(Region region)
        {
            var data = await facade.CallApi<ApiListDataResponse<CountryIntensityData>>($"regional/regionid/{(int)region}");

            data.Data.AssertHasSingleEntry();
            data.Data[0].Intensities.AssertHasSingleEntry();

            return data.Data[0];
        }

        public async Task<RegionalIntensityData[]> GetRegionalData(DateTime from, DateTime to)
        {
            var data = await facade.CallApi<ApiListDataResponse<RegionalIntensityData>>($"regional/intensity/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}");
            return data.Data;
        }

        public async Task<PostcodeIntensityData> GetRegionalData(DateTime from, DateTime to, string postcode)
        {
            var data = await facade.CallApi<ApiDataResponse<PostcodeIntensityData>>($"regional/intensity/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}/postcode/{postcode}");
            return data.Data;
        }

        public async Task<CountryIntensityData> GetRegionalData(DateTime from, DateTime to, Region region)
        {
            var data = await facade.CallApi<ApiDataResponse<CountryIntensityData>>($"regional/intensity/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}/regionid/{(int)region}");
            return data.Data;
        }
    }
}
