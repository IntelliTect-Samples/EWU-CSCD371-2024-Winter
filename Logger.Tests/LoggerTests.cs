namespace Logger.Tests;

public class LoggerTests : BaseLogger, ILogger
{
    public LoggerTests(string logSource) : base(logSource) { }
    
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public static ILogger CreateLogger(in TestLoggerConfiguration configuration) => 
        new LoggerTests(configuration.LogSource);

    static ILogger ILogger.CreateLogger(in ILoggerConfiguration configuration) => 
        configuration is TestLoggerConfiguration testLoggerConfiguration
            ? CreateLogger(testLoggerConfiguration)
            : throw new ArgumentException("Invalid configuration type", nameof(configuration));

    public override void Log(LogLevel logLevel, string message) => LoggedMessages.Add((logLevel, message));
}

public class TestLoggerConfiguration : BaseLoggerConfiguration, ILoggerConfiguration
{
    public TestLoggerConfiguration(string logSource) : base(logSource) { }

}
