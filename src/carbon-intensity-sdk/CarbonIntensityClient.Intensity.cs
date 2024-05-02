using CarbonIntensitySdk.Models;
using CarbonIntensitySdk.Extensions;

namespace CarbonIntensitySdk
{
    public partial class CarbonIntensityClient(CarbonIntensityFacade facade)
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
        /// Get Carbon Intensity data for specific date
        /// </summary>
        /// <param name="date">Date in YYYY-MM-DD format e.g. 2017-08-25</param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensitiesForDate(DateTime date)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityData>>($"intensity/date/{date:yyyy-MM-dd}T00:00:00Z");

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
        public async Task<CarbonIntensityStatisticsData> GetIntensityStatsBetween(DateTime from, DateTime to)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityStatisticsData>>($"intensity/stats/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}");

            data.Data.AssertHasSingleEntry();

            return data.Data[0];
        }

        /// <summary>
        /// Get block average Carbon Intensity statistics between from and to datetime
        /// </summary>
        /// <param name="from">Start datetime in ISO8601 format YYYY-MM-DDThh:mmZ e.g. '2017-08-25T12:35Z'</param>
        /// <param name="to">End datetime in ISO8601 format YYYY-MM-DDThh:mmZ e.g. '2017-08-26T17:00Z'</param>
        /// <param name="blockLengthHours">Block length in hours i.e. a block length of 2 hrs over a 24 hr period returns 12 items with the average, max, min for each 2 hr block e.g. 2017-08-26T17:00Z/2017-08-27T17:00Z/2</param>
        /// <returns><see cref="T:CarbonIntensityStatisticsData[]"/></returns>
        public async Task<CarbonIntensityStatisticsData[]> GetBlockAverageIntensityStats(DateTime from, DateTime to, int blockLengthHours)
        {
            var data = await facade.CallApi<ApiListDataResponse<CarbonIntensityStatisticsData>>($"intensity/stats/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}/{blockLengthHours}");

            return data.Data;
        }
    }
}
