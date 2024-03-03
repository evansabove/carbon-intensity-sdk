using CarbonIntensitySdk.Models;

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
            var data = await facade.CallApi<CarbonIntensityData>("intensity");

            data.AssertHasSingleDataEntry();
            
            return data.Data[0];
        }

        /// <summary>
        /// Get Carbon Intensity data for today
        /// </summary>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensityForToday()
        {
            var data = await facade.CallApi<CarbonIntensityData>("intensity/date");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data for specific date
        /// </summary>
        /// <param name="date">Date in YYYY-MM-DD format e.g. 2017-08-25</param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensityForDate(DateTime date)
        {
            var data = await facade.CallApi<CarbonIntensityData>($"intensity/date/{date:yyyy-MM-dd}");

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
            var data = await facade.CallApi<CarbonIntensityData>($"intensity/date/{date:yyyy-MM-dd}/{period}");

            data.AssertHasSingleDataEntry();

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity factors for each fuel type
        /// </summary>
        /// <returns><see cref="T:CarbonFactors"/></returns>
        public async Task<CarbonFactors> GetCarbonFactors()
        {
            var data = await facade.CallApi<CarbonFactors>("intensity/factors");

            data.AssertHasSingleDataEntry();

            return data.Data[0];
        }

        /// <summary>
        /// Get Carbon Intensity data for specific half hour period
        /// </summary>
        /// <param name="from"></param>
        /// <returns><see cref="T:CarbonIntensityData"/></returns>
        public async Task<CarbonIntensityData> GetIntensityFrom(DateTime from)
        {
            var data = await facade.CallApi<CarbonIntensityData>($"intensity/{from:yyyy-MM-ddTHH:mmZ}");

            data.AssertHasSingleDataEntry();

            return data.Data[0];
        }

        /// <summary>
        /// Get Carbon Intensity data 24hrs forwards from specific datetime
        /// </summary>
        /// <param name="from"></param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensity24HForwardsFrom(DateTime from)
        {
            var data = await facade.CallApi<CarbonIntensityData>($"intensity/{from:yyyy-MM-ddTHH:mmZ}/fw24h");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data 48hrs forwards from specific datetime
        /// </summary>
        /// <param name="from"></param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensity48HForwardsFrom(DateTime from)
        {
            var data = await facade.CallApi<CarbonIntensityData>($"intensity/{from:yyyy-MM-ddTHH:mmZ}/fw48h");

            return data.Data;
        }

        /// <summary>
        /// Get Carbon Intensity data 24hrs in the past of a specific datetime
        /// </summary>
        /// <param name="from"></param>
        /// <returns><see cref="T:CarbonIntensityData[]"/></returns>
        public async Task<CarbonIntensityData[]> GetIntensity24HPastFrom(DateTime from)
        {
            var data = await facade.CallApi<CarbonIntensityData>($"intensity/{from:yyyy-MM-ddTHH:mmZ}/pt24h");

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
            var data = await facade.CallApi<CarbonIntensityData>($"intensity/{from:yyyy-MM-ddTHH:mmZ}/{to:yyyy-MM-ddTHH:mmZ}");

            return data.Data;
        }
    }
}
