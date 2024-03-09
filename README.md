# Carbon Intensity SDK

An unofficial library for the [Carbon Intensity API](https://carbonintensity.org.uk/) for use in C# applications.

## Getting Started

1. Install the package from NuGet
1. Register the SDK in your `Startup.cs` file:

```csharp
builder.Services.AddCarbonIntensitySdk();
```

3. Inject the `CarbonIntensityClient` into your service or controller.

### Original documentation
The original documentation for the Carbon Intensity API can be found [here](https://carbon-intensity.github.io/api-definitions/#carbon-intensity-api-v2-0-0).

## Terms of Use
Ensure you abide by the terms of use for the Carbon Intensity API. You can find them [here](https://carbonintensity.org.uk/terms/).