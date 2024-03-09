using AutoFixture;
using Shouldly;
using Xunit;

namespace CarbonIntensitySdk.Test;

public class WhenGettingGenerationData : BaseTest
{
    [Fact]
    public async Task ShouldGetGenerationMix()
    {
        var fixture = new Fixture();
        var client = fixture.Create<CarbonIntensityClient>();

        var generationMix = await client.GetGenerationMix();

        generationMix.BiomassPercentage.HasValue.ShouldBeTrue();
        generationMix.CoalPercentage.HasValue.ShouldBeTrue();
        generationMix.GasPercentage.HasValue.ShouldBeTrue();
        generationMix.HydroPercentage.HasValue.ShouldBeTrue();
        generationMix.ImportsPercentage.HasValue.ShouldBeTrue();
        generationMix.NuclearPercentage.HasValue.ShouldBeTrue();
        generationMix.OtherPercentage.HasValue.ShouldBeTrue();
        generationMix.SolarPercentage.HasValue.ShouldBeTrue();
        generationMix.WindPercentage.HasValue.ShouldBeTrue();
    }

    [Fact]
    public async Task ShouldGetGenerationMixBetweenDates()
    {
        var fixture = new Fixture();
        var client = fixture.Create<CarbonIntensityClient>();

        var from = DateTime.Today;
        var to = from.AddHours(2);

        var generationMix = await client.GetGenerationMix(from, to);
        generationMix.Length.ShouldBe(5);

        generationMix.MinBy(x => x.FromUtc)!.FromUtc.ShouldBe(from.AddMinutes(-30));
        generationMix.MaxBy(x => x.ToUtc)!.ToUtc.ShouldBe(to);
    }
}