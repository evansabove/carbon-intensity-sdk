using AutoFixture;
using CarbonIntensitySdk.Enums;
using Xunit;

namespace CarbonIntensitySdk.Test;

public class WhenGettingRegionalData : BaseTest
{
    [Fact]
    public async Task ShouldGetRegionalData()
    {
        var fixture = new Fixture();
        var client = fixture.Create<CarbonIntensityClient>();

        _ = await client.GetRegionalData();
    }

    [Fact]
    public async Task ShouldGetRegionalDataBetween()
    {
        var fixture = new Fixture();
        var client = fixture.Create<CarbonIntensityClient>();

        _ = await client.GetRegionalData(DateTime.Today, DateTime.Today.AddHours(1));
    }

    [Fact]
    public async Task ShouldGetCountryData()
    {
        var fixture = new Fixture();
        var client = fixture.Create<CarbonIntensityClient>();

        _ = await client.GetCountryData(Country.England);
    }

    [Fact]
    public async Task ShouldGetPostcodeData()
    { 
        var fixture = new Fixture();
        var client = fixture.Create<CarbonIntensityClient>();

        _ = await client.GetPostcodeData("SW1A");
    }

    [Fact]
    public async Task ShouldGetPostcodeDataBetween()
    {
        var fixture = new Fixture();
        var client = fixture.Create<CarbonIntensityClient>();

        _ = await client.GetPostcodeData("SW1A", DateTime.Today, DateTime.Today.AddHours(1));
    }

    [Fact]
    public async Task ShouldGetRegionData()
    {
        var fixture = new Fixture();
        var client = fixture.Create<CarbonIntensityClient>();

        _ = await client.GetRegionData(Region.NorthWales);
    }

    [Fact]
    public async Task ShouldGetRegionDataBetween()
    {
        var fixture = new Fixture();
        var client = fixture.Create<CarbonIntensityClient>();

        _ = await client.GetRegionData(Region.NorthWales, DateTime.Today, DateTime.Today.AddHours(1));
    }
}