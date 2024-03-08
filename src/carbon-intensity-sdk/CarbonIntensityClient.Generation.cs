using CarbonIntensitySdk.Models;

namespace CarbonIntensitySdk
{
    public partial class CarbonIntensityClient
    {
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
    }
}
