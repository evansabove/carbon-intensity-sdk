using Xunit;
using AutoFixture;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shouldly;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarbonIntensitySdk.Test
{
    public class WhenGettingIntensity : BaseTest
    {
        [Fact]
        public async Task ShouldGetIntensityForCurrentHalfHour()
        {
            var fixture = new Fixture();

            var client = fixture.Create<CarbonIntensityClient>();
            _ = await client.GetIntensityForCurrentHalfHour();
        }

        [Fact]
        public async Task ShouldGetIntensitiesForToday()
        {
            var fixture = new Fixture();

            var client = fixture.Create<CarbonIntensityClient>();
            var intensities = await client.GetIntensitiesForToday();

            intensities.Length.ShouldBe(48);
            intensities.MinBy(x => x.FromUtc)!.FromUtc.ShouldBe(DateTime.Today);
            intensities.MaxBy(x => x.ToUtc)!.ToUtc.ShouldBe(DateTime.Today.AddDays(1));
        }

        [Fact]
        public async Task ShouldGetIntensitiesForDate()
        {
            var fixture = new Fixture();

            var client = fixture.Create<CarbonIntensityClient>();

            var date = DateTime.Today.AddDays(-1);
            var intensities = await client.GetIntensitiesForDate(date);

            intensities.Length.ShouldBe(48);
            intensities.MinBy(x => x.FromUtc)!.FromUtc.ShouldBe(date);
            intensities.MaxBy(x => x.ToUtc)!.ToUtc.ShouldBe(date.AddDays(1));
        }

        [Fact]
        public async Task ShouldGetIntensityForDateAndPeriod()
        {
            var fixture = new Fixture();

            var client = fixture.Create<CarbonIntensityClient>();

            var date = DateTime.Today.AddDays(-1);
            int period = 5;
            var intensity = await client.GetIntensityForDateAndPeriod(date, period);

            intensity.FromUtc.ShouldBe(date.AddMinutes(30 * (period - 1)));
            intensity.ToUtc.ShouldBe(date.AddMinutes(30 * period));
        }

        [Fact]
        public async Task ShouldGetCarbonFactors()
        {
            var fixture = new Fixture();

            var client = fixture.Create<CarbonIntensityClient>();

            _ = await client.GetCarbonFactors();
        }

        [Fact]
        public async Task ShouldGetIntensityFrom()
        {
            var fixture = new Fixture();

            var client = fixture.Create<CarbonIntensityClient>();

            _ = await client.GetIntensityFrom(DateTime.Today);
        }

        [Fact]
        public async Task ShouldGetIntensityBetween()
        {
            var fixture = new Fixture();

            var client = fixture.Create<CarbonIntensityClient>();

            var from = DateTime.Today;
            var to = from.AddHours(1);
            var intensities = await client.GetIntensityBetween(from, to);
            
            intensities.Length.ShouldBe(3);
            intensities.MinBy(x => x.FromUtc)!.FromUtc.ShouldBe(from.AddMinutes(-30));
            intensities.MaxBy(x => x.ToUtc)!.ToUtc.ShouldBe(to);
        }

        [Fact]
        public async Task ShouldGetIntensityStatsBetween()
        {
            var fixture = new Fixture();

            var client = fixture.Create<CarbonIntensityClient>();

            var from = DateTime.Today;
            var to = from.AddHours(1);
            var intensities = await client.GetIntensityStatsBetween(from, to);

            intensities.FromUtc.ShouldBe(from);
            intensities.ToUtc.ShouldBe(to);
        }

        [Fact]
        public async Task ShouldGetBlockAverageIntensityStatsBetween()
        {
            var fixture = new Fixture();

            var client = fixture.Create<CarbonIntensityClient>();

            var from = DateTime.Today;
            var to = from.AddDays(1);
            var intensities = await client.GetBlockAverageIntensityStats(from, to, 2);

            intensities.Length.ShouldBe(12);
            intensities.MinBy(x => x.FromUtc)!.FromUtc.ShouldBe(from);
            intensities.MaxBy(x => x.ToUtc)!.ToUtc.ShouldBe(to);
        }
    }
}