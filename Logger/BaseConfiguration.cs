namespace Logger;
//TODO: This could be abstract since you wouldn't need to create your own BaseLoggerConfiguration
//because it woudln't be able to do anything.
public class BaseLoggerConfiguration : ILoggerConfiguration
{
    public BaseLoggerConfiguration(string logSource) => LogSource = string.IsNullOrWhiteSpace(logSource)
            ? throw new ArgumentException($"'{nameof(logSource)}' cannot be null or whitespace.", nameof(logSource))
            : logSource;
    
    public string LogSource { get; }
    
}