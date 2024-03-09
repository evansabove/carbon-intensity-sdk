namespace CarbonIntensitySdk.Test;

public abstract class BaseTest
{
    protected BaseTest()
    {
        RateLimitTests();
    }

    private static void RateLimitTests()
    {
        Thread.Sleep(1000);
    }
}