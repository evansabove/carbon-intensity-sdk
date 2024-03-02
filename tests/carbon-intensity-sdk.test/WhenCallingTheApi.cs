using Flurl.Http.Testing;
using Shouldly;
using Xunit;
using AutoFixture.AutoNSubstitute;
using AutoFixture;

namespace CarbonIntensitySdk.Test
{
    public class WhenCallingTheApi
    {
        private const string SampleResponse = """
                                              {
                                                "data":[{
                                                    "from": "2018-01-20T12:00Z",
                                                    "to": "2018-01-20T12:30Z",
                                                    "intensity": {
                                                      "forecast": 266,
                                                      "actual": 263,
                                                      "index": "moderate"
                                                    }
                                                }]
                                              }
                                              """;

        [Fact]
        public async Task ShouldDeserializeResponse()
        {
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());

            using var httpTest = new HttpTest();

            httpTest.ForCallsTo($"{CarbonIntensityFacade.BaseUri}intensity")
                .WithVerb(HttpMethod.Get)
                .RespondWith(SampleResponse);
            
            var client = fixture.Create<CarbonIntensityClient>();

            var result = await client.GetIntensity();

            result.FromUtc.ShouldBe(new DateTime(2018, 1, 20, 12, 0, 0, 0));
            result.ToUtc.ShouldBe(new DateTime(2018, 1, 20, 12, 30, 0, 0));
            
            result.Intensity.ShouldNotBeNull();
            result.Intensity.Forecast.ShouldBe(266);
            result.Intensity.Actual.ShouldBe(263);
            result.Intensity.Index.ShouldBe("moderate");
        }
    }
}