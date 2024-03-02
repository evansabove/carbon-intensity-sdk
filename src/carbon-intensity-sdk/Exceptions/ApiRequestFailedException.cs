namespace CarbonIntensitySdk.Exceptions;

public class ApiRequestFailedException(string error): Exception(error);