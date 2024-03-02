namespace CarbonIntensitySdk.Exceptions;

public class UnexpectedApiResponseException(string error) : Exception(error);