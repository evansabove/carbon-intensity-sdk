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
        /// <returns><see cref="T:AllRegionData"/></returns>
        public async Task<AllRegionData[]> GetAllRegionalData()
        {
            var data = await facade.CallApi<ApiListDataResponse<AllRegionData>>("regional");

            return data.Data;
        }

        public async Task<AllRegionData[]> GetAllRegionalData(DateTime from, DateTime to)
        {
            var data = await facade.CallApi<ApiListDataResponse<AllRegionData>>($"regional/intensity/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}");
            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data for current half hour for the specified country
        /// </summary>
        /// <param name="country"></param>
        /// <returns><see cref="T:RegionIntensityData"/></returns>
        public async Task<RegionIntensityData> GetCountryData(Country country)
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

        public async Task<PostcodeIntensityData> GetPostcodeData(string postcode, DateTime from, DateTime to)
        {
            var data = await facade.CallApi<ApiDataResponse<PostcodeIntensityData>>($"regional/intensity/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}/postcode/{postcode}");
            return data.Data;
        }

        public async Task<RegionIntensityData> GetRegionData(Region region)
        {
            var data = await facade.CallApi<ApiListDataResponse<RegionIntensityData>>($"regional/regionid/{(int)region}");

            data.Data.AssertHasSingleEntry();
            data.Data[0].Intensities.AssertHasSingleEntry();

            return data.Data[0];
        }

        public async Task<RegionIntensityData> GetRegionData(Region region, DateTime from, DateTime to)
        {
            var data = await facade.CallApi<ApiDataResponse<RegionIntensityData>>($"regional/intensity/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}/regionid/{(int)region}");
            return data.Data;
        }
    }
}
