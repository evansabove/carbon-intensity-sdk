using Xunit;
using AutoFixture;
using Shouldly;

namespace CarbonIntensitySdk.Test;

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
