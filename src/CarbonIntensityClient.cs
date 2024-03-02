using CarbonIntensitySdk.Exceptions;
using CarbonIntensitySdk.Models;

namespace CarbonIntensitySdk
{
    public class CarbonIntensityClient(CarbonIntensityFacade carbonIntensityFacade)
    {
        /// <summary>
        /// Get Carbon Intensity data for current half hour
        /// </summary>
        /// <returns></returns>
        public async Task<IntensityData> GetIntensity()
        {
            var data = await carbonIntensityFacade.CallApi("intensity");

            AssertHasSingleDataEntry(data);
            
            return data[0];
        }

        //extract this into a fluent validator style pattern where we 'validate' the response we've received?
        private void AssertHasSingleDataEntry(IReadOnlyCollection<IntensityData> data)
        {
            if (data == null || !data.Any())
            {
                throw new UnexpectedApiResponseException("Expected single result but none were found");
            }

            if (data.Count > 1)
            {
                throw new UnexpectedApiResponseException("Only 1 result expected but multiple were found");
            }
        }
    }
}
