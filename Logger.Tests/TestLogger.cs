namespace Logger.Tests;

public class TestLogger : BaseLogger, ILogger<TestLogger>
{
    public TestLogger(string logSource) : base(logSource) { }
    
    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();
    //TODO making this constructor public will allow people to call this one instead of
    //The other one which checks for null configuration. Making this private makes it so they have to use other one
    public static TestLogger CreateLogger(TestLoggerConfiguration configuration) => 
        new TestLogger(configuration.LogSource);

    public static TestLogger CreateLogger<T>(in T logggerConfiguration) where T : ILoggerConfiguration=>
        logggerConfiguration is TestLoggerConfiguration configuration
            ? CreateLogger(configuration)
            : throw new ArgumentException("Invalid configuration type", nameof(logggerConfiguration));

    public override void Log(LogLevel logLevel, string message) => LoggedMessages.Add((logLevel, message));
}

public class TestLoggerConfiguration : BaseLoggerConfiguration, ILoggerConfiguration
{
    public TestLoggerConfiguration(string logSource) : base(logSource) { }

}
