using CarbonIntensitySdk.Exceptions;
using CarbonIntensitySdk.Models;

namespace CarbonIntensitySdk
{
    public class CarbonIntensityClient(CarbonIntensityFacade facade)
    {
        /// <summary>
        /// Get Carbon Intensity data for current half hour
        /// </summary>
        /// <returns><see cref="T:IntensityData"/></returns>
        public async Task<CarbonIntensityData> GetIntensityForCurrentHalfHour()
        {
            var data = await facade.CallApi<ApiDataResponse<CarbonIntensityData>>("intensity");

            AssertHasSingleDataEntry(data);
            
            return data.Data[0];
        }

        /// <summary>
        /// Get Carbon Intensity data for today
        /// </summary>
        /// <returns><see cref="T:IntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensityForToday()
        {
            var data = await facade.CallApi<ApiDataResponse<CarbonIntensityData>>("intensity/date");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data for specific date
        /// </summary>
        /// <param name="date">Date in YYYY-MM-DD format e.g. 2017-08-25</param>
        /// <returns><see cref="T:IntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensityForDate(DateTime date)
        {
            var data = await facade.CallApi<ApiDataResponse<CarbonIntensityData>>($"intensity/date/{date:yyyy-MM-dd}");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data for a specific date and half hour settlement period
        /// </summary>
        /// <param name="date">Date in YYYY-MM-DD format e.g. 2017-08-25</param>
        /// <param name="period">Half hour settlement period between 1-48 e.g. 42</param>
        /// <returns><see cref="T:IntensityData"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensityForDateAndPeriod(DateTime date, int period)
        {
            var data = await facade.CallApi<ApiDataResponse<CarbonIntensityData>>($"intensity/date/{date:yyyy-MM-dd}/{period}");

            AssertHasSingleDataEntry(data);

            return data.Data;
        }

        public async Task<CarbonFactors> GetCarbonFactors()
        {
            var data = await facade.CallApi<ApiDataResponse<CarbonFactors>>("intensity/factors");

            AssertHasSingleDataEntry(data);

            return data.Data[0];
        }

        //extract this into a fluent validator style pattern where we 'validate' the response we've received?
        private void AssertHasSingleDataEntry<T>(ApiDataResponse<T> data)
        {
            if (!data.Data.Any())
            {
                throw new UnexpectedApiResponseException("Expected single result but none were found");
            }

            if (data.Data.Length > 1)
            {
                throw new UnexpectedApiResponseException("Only 1 result expected but multiple were found");
            }
        }
    }
}
