using Xunit;
namespace Logger.Tests;

    public class LoggerFactoryTests
    {

    [Fact]
    public void CreateLogger_FileLoggerValidConfigruation_ReturnsFileLogger()
    {
        LoggerFactory<FileLogger> fileLoggerfactory = new();

        FileLogger fileLogger = (FileLogger)fileLoggerfactory.CreateLogger(new FileLoggerConfiguration("Path", nameof(LoggerFactoryTests)))!;

        Assert.IsType<FileLogger>(fileLogger);
        Assert.Equal(nameof(LoggerFactoryTests), fileLogger.LogSource);
        Assert.Equal(new FileInfo("Path").FullName, fileLogger.FilePath);


    }
    [Fact]
    public void CreateLogger_FileLoggerInvalidConfiguration_ThrowArgumentException()
    {
        LoggerFactory<FileLogger> fileLoggerfactory = new();
        Assert.Throws<ArgumentException>(() => fileLoggerfactory.CreateLogger(new TestLoggerConfiguration(nameof(LoggerFactoryTests))));
    }
    [Fact]
    public void CreateLogger_UnSupportedLoggerValidConfiguration_ReturnsNull()
    {
        LoggerFactory<TestLogger> testLoggerfactory = new();

        var testLogger = testLoggerfactory.CreateLogger(new FileLoggerConfiguration("Path", "Logger"));

        Assert.Null(testLogger);
    }

    }

