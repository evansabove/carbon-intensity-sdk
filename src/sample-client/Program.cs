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

            var thisHalfHour = await client.GetIntensityForCurrentHalfHour();
            var yesterday = await client.GetIntensityForDate(DateTime.Today.AddDays(-1));
            var today = await client.GetIntensityForToday();
            var dateAndPeriod = await client.GetIntensityForDateAndPeriod(DateTime.Today, 11);
        }
    }
}
