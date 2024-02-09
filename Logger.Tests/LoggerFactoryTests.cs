using Xunit;
namespace Logger.Tests;

    public class LoggerFactoryTests
    {

    [Fact]
    public void CreateLogger_FileLoggerValidConfigruation_ReturnsFileLogger()
    {
        LoggerFactory<FileLogger> factory = new();

        var fileLogger = factory.CreateLogger<FileLoggerConfiguration>(new FileLoggerConfiguration("Path", "Logger"));

        Assert.IsType<FileLogger>(fileLogger);

    }

    }

