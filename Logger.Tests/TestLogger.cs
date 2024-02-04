namespace Logger.Tests;

public class TestLogger : BaseLogger, ILogger<TestLogger>
{
    public TestLogger(string logSource) : base(logSource) { }
    
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

    public static TestLogger CreateLogger(in TestLoggerConfiguration configuration) => 
        new TestLogger(configuration.LogSource);

    public static TestLogger CreateLogger<T>(in T logggerConfiguration) =>
        logggerConfiguration is TestLoggerConfiguration configuration
            ? CreateLogger(configuration)
            : throw new ArgumentException("Invalid configuration type", nameof(logggerConfiguration));

    static TestLogger ILogger<TestLogger>.CreateLogger<T2>(in T2 configuration)
    {
        throw new NotImplementedException();
    }

    public override void Log(LogLevel logLevel, string message) => LoggedMessages.Add((logLevel, message));
}

public class TestLoggerConfiguration : BaseLoggerConfiguration, ILoggerConfiguration
{
    public TestLoggerConfiguration(string logSource) : base(logSource) { }

}
