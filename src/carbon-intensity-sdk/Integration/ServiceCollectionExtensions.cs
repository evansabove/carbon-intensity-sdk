using Microsoft.Extensions.DependencyInjection;

namespace CarbonIntensitySdk.Integration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCarbonIntensitySdk(this IServiceCollection services)
        {
            services.AddTransient<CarbonIntensityFacade>();
            services.AddTransient<CarbonIntensityClient>();
            return services;
        }
    }
}
