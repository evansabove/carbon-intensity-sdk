using System.Text.Json.Serialization;

namespace CarbonIntensitySdk.Models
{
    public record CarbonFactors
    {
        [JsonPropertyName("Biomass")]
        public int Biomass { get; init; }

        [JsonPropertyName("Coal")]
        public int Coal { get; init; }

        [JsonPropertyName("Dutch Imports")]
        public int DutchImports { get; init; }

        [JsonPropertyName("French Imports")]
        public int FrenchImports { get; init; }

        [JsonPropertyName("Gas (Combined Cycle)")]
        public int GasCombinedCycle { get; init; }

        [JsonPropertyName("Gas (Open Cycle)")]
        public int GasOpenCycle { get; init; }

        [JsonPropertyName("Hydro")]
        public int Hydro { get; init; }

        [JsonPropertyName("Irish Imports")]
        public int IrishImports { get; init; }

        [JsonPropertyName("Nuclear")]
        public int Nuclear { get; init; }

        [JsonPropertyName("Oil")]
        public int Oil { get; init; }

        [JsonPropertyName("Other")]
        public int Other { get; init; }

        [JsonPropertyName("Pumped Storage")]
        public int PumpedStorage { get; init; }

        [JsonPropertyName("Solar")]
        public int Solar { get; init; }

        [JsonPropertyName("Wind")]
        public int Wind { get; init; }
    }
}
