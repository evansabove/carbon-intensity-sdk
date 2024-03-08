using CarbonIntensitySdk.Enums;
using CarbonIntensitySdk.Extensions;
using CarbonIntensitySdk.Models;
using System.Diagnostics.Metrics;

namespace CarbonIntensitySdk
{
    public class CarbonIntensityClient(CarbonIntensityFacade facade)
    {
        /// <summary>
        /// Get Carbon Intensity data for current half hour
        /// </summary>
        /// <returns><see cref="T:CarbonIntensityData"/></returns>
        public async Task<CarbonIntensityData> GetIntensityForCurrentHalfHour()
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>("intensity");

            data.Data.AssertHasSingleEntry();
            
            return data.Data[0];
        }

        /// <summary>
        /// Get Carbon Intensity data for today
        /// </summary>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensityForToday()
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>("intensity/date");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data for specific date
        /// </summary>
        /// <param name="date">Date in YYYY-MM-DD format e.g. 2017-08-25</param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensityForDate(DateTime date)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>($"intensity/date/{date:yyyy-MM-dd}");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data for a specific date and half hour settlement period
        /// </summary>
        /// <param name="date">Date in YYYY-MM-DD format e.g. 2017-08-25</param>
        /// <param name="period">Half hour settlement period between 1-48 e.g. 42</param>
        /// <returns><see cref="T:CarbonIntensityData"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensityForDateAndPeriod(DateTime date, int period)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>($"intensity/date/{date:yyyy-MM-dd}/{period}");

            data.Data.AssertHasSingleEntry();

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity factors for each fuel type
        /// </summary>
        /// <returns><see cref="T:CarbonFactors"/></returns>
        public async Task<CarbonFactors> GetCarbonFactors()
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonFactors>>("intensity/factors");

            data.Data.AssertHasSingleEntry();

            return data.Data[0];
        }

        /// <summary>
        /// Get Carbon Intensity data for specific half hour period
        /// </summary>
        /// <param name="from"></param>
        /// <returns><see cref="T:CarbonIntensityData"/></returns>
        public async Task<CarbonIntensityData> GetIntensityFrom(DateTime from)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>($"intensity/{from:yyyy-MM-ddTHH:mmZ}");

            data.Data.AssertHasSingleEntry();

            return data.Data[0];
        }

        /// <summary>
        /// Get Carbon Intensity data 24hrs forwards from specific datetime
        /// </summary>
        /// <param name="from"></param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensity24HForwardsFrom(DateTime from)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>($"intensity/{from:yyyy-MM-ddTHH:mmZ}/fw24h");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data 48hrs forwards from specific datetime
        /// </summary>
        /// <param name="from"></param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensity48HForwardsFrom(DateTime from)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>($"intensity/{from:yyyy-MM-ddTHH:mmZ}/fw48h");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data 24hrs in the past of a specific datetime
        /// </summary>
        /// <param name="from"></param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensity24HBefore(DateTime before)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>($"intensity/{before:yyyy-MM-ddTHH:mmZ}/pt24h");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data between from and to datetime
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensityBetween(DateTime from, DateTime to)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>($"intensity/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity statistics between from and to datetime
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns><see cref="T:CarbonIntensityStatisticsData[]"/></returns>
        public async Task<CarbonIntensityStatisticsData[]> GetIntensityStatsBetween(DateTime from, DateTime to)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityStatisticsData>>($"intensity/stats/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}");

            return data.Data;
        }

        /// <summary>
        /// Get block average Carbon Intensity statistics between from and to datetime
        /// </summary>
        /// <param name="from">Start datetime in ISO8601 format YYYY-MM-DDThh:mmZ e.g. '2017-08-25T12:35Z'</param>
        /// <param name="to">End datetime in ISO8601 format YYYY-MM-DDThh:mmZ e.g. '2017-08-26T17:00Z'</param>
        /// <param name="blockLengthHours">Block length in hours i.e. a block length of 2 hrs over a 24 hr period returns 12 items with the average, max, min for each 2 hr block e.g. 2017-08-26T17:00Z/2017-08-27T17:00Z/2</param>
        /// <returns><see cref="T:CarbonIntensityStatisticsData[]"/></returns>
        public async Task<CarbonIntensityStatisticsData[]> GetBlockAverageIntensityStatsBetween(DateTime from, DateTime to, int blockLengthHours)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityStatisticsData>>($"intensity/stats/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}/{blockLengthHours}");

            return data.Data;
        }

        /// <summary>
        /// Get generation mix for current half hour
        /// </summary>
        /// <returns><see cref="T:GenerationMixData"/></returns>
        public async Task<GenerationMixData> GetGenerationMix()
        {
            var data = await facade.CallApi<ApiDataResponse<GenerationMixData>>("generation");

            return data.Data;
        }

        /// <summary>
        /// Get generation mix for the past 24 hours
        /// </summary>
        /// <param name="before"></param>
        /// <returns></returns>
        public async Task<GenerationMixData[]> GetGenerationMix24HBefore(DateTime before)
        {
            var data = await facade.CallApi<ApiListDataResponse<GenerationMixData>>($"generation/{before:yyyy-MM-ddTHH:mmZ}/pt24h");

            return data.Data;
        }

        /// <summary>
        /// Get generation mix between from and to datetimes
        /// </summary>
        /// <param name="from">Start Datetime in in ISO8601 format YYYY-MM-DDThh:mmZ e.g. 2017-08-25T12:35Z</param>
        /// <param name="to">End datetime in in ISO8601 format YYYY-MM-DDThh:mmZ e.g. 2017-08-25T12:35Z</param>
        /// <returns><see cref="T:GenerationMixData[]"/></returns>
        public async Task<GenerationMixData[]> GetGenerationMix(DateTime from, DateTime to)
        {
            var data = await facade.CallApi<ApiListDataResponse<GenerationMixData>>($"generation/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}");

            return data.Data;
        }

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
