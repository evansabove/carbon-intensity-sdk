using CarbonIntensitySdk;
using CarbonIntensitySdk.Integration;
using Microsoft.Extensions.DependencyInjection;

namespace sample_client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddCarbonIntensitySdk()
                .BuildServiceProvider();

            var client = serviceProvider.GetRequiredService<CarbonIntensityClient>();

            //var thisHalfHour = await client.GetIntensityForCurrentHalfHour();
            //var yesterday = await client.GetIntensityForDate(DateTime.Today.AddDays(-1));
            //var today = await client.GetIntensityForToday();
            //var dateAndPeriod = await client.GetIntensityForDateAndPeriod(DateTime.Today, 11);
            //var factors = await client.GetCarbonFactors();
            //var intensityFrom = await client.GetIntensityFrom(DateTime.Now);
            //var forward24hFrom = await client.GetIntensity24HForwardsFrom(DateTime.Now);
            //var forward48hFrom = await client.GetIntensity48HForwardsFrom(DateTime.Now);
            //var past24hfrom = await client.GetIntensity24HPastFrom(DateTime.Now);
            //var between = await client.GetIntensityBetween(DateTime.Now, DateTime.Now.AddHours(2));
        }
    }
}
