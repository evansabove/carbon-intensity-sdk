﻿using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models;

public record RegionIntensity : TimeBoxedData
{
    [JsonPropertyName("intensity")]
    public required CarbonIntensity Intensity { get; init; }

    [JsonPropertyName("generationmix")]
    public required GenerationMix[] GenerationMix { get; init; }
}