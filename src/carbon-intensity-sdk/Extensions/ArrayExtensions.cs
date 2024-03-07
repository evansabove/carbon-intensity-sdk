using CarbonIntensitySdk.Exceptions;

namespace CarbonIntensitySdk.Extensions
{
    public static class ArrayExtensions
    {
        public static void AssertHasSingleEntry<T>(this T[] data)
        {
            if (!data.Any())
            {
                throw new UnexpectedApiResponseException("Expected single result but none were found");
            }

            if (data.Count() > 1)
            {
                throw new UnexpectedApiResponseException("Only 1 result expected but multiple were found");
            }
        }
    }
}
