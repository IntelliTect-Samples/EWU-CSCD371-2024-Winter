namespace Logger.Tests;

public class TestLogger : BaseLogger, ILogger<TestLogger>
{
    public TestLogger(string logSource) : base(logSource) { }
    
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public static TestLogger CreateLogger(in TestLoggerConfiguration configuration) => 
        new TestLogger(configuration.LogSource);

    static TestLogger ILogger<TestLogger>.CreateLogger(in ILoggerConfiguration configuration) => 
        configuration is TestLoggerConfiguration testLoggerConfiguration
            ? CreateLogger(testLoggerConfiguration)
            : throw new ArgumentException("Invalid configuration type", nameof(configuration));

    public override void Log(LogLevel logLevel, string message) => LoggedMessages.Add((logLevel, message));
}

public class TestLoggerConfiguration : BaseLoggerConfiguration, ILoggerConfiguration
{
    public TestLoggerConfiguration(string logSource) : base(logSource) { }

}
