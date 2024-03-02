using Flurl.Http.Testing;
using Shouldly;
using Xunit;
using AutoFixture.AutoNSubstitute;
using AutoFixture;
using CarbonIntensitySdk.Exceptions;
using CarbonIntensitySdk.Models;

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

            var result = await client.GetIntensityForCurrentHalfHour();

            result.FromUtc.ShouldBe(new DateTime(2018, 1, 20, 12, 0, 0, 0));
            result.ToUtc.ShouldBe(new DateTime(2018, 1, 20, 12, 30, 0, 0));
            
            result.Intensity.ShouldNotBeNull();
            result.Intensity.Forecast.ShouldBe(266);
            result.Intensity.Actual.ShouldBe(263);
            result.Intensity.Index.ShouldBe("moderate");
        }

        [Fact]
        public async Task ShouldHandleErrorResponse()
        {
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());

            using var httpTest = new HttpTest();

            var sampleError = new ErrorResponse()
            {
                Error = new Error
                {
                    Code = "400",
                    Message = "You made a bad request"
                }
            };

            httpTest.ForCallsTo($"{CarbonIntensityFacade.BaseUri}intensity")
                .WithVerb(HttpMethod.Get)
                .RespondWithJson(sampleError, 400);

            var client = fixture.Create<CarbonIntensityClient>();

            var receivedException = await client.GetIntensityForCurrentHalfHour().ShouldThrowAsync(typeof(ApiRequestFailedException));
            receivedException.Message.ShouldBe("API request to path \"intensity\" failed with error code 400 and message \"You made a bad request\"");
        }
    }
}