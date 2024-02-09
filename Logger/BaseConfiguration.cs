namespace Logger;

public class BaseLoggerConfiguration(string logSource) : ILoggerConfiguration
{
    public string LogSource { get; } = string.IsNullOrWhiteSpace(logSource)
            ? throw new ArgumentException($"'{nameof(logSource)}' cannot be null or whitespace.", nameof(logSource))
            : logSource;

}