using Xunit;

namespace Logger.Tests;

public class FileLoggerTests : FileLoggerTestsBase
{    
    [Fact]
    public void Create_GivenClassAndValidFileName_Success()
    {
        Assert.Equal(nameof(FileLoggerTests), Logger.LogSource);
        Assert.Equal(FilePath, Logger.FilePath);

    }
    //This was added to check if generic method was working, not a already made tests
    [Fact]
    public void CreateLoggerGeneric_ValidFileLoggerConfiguration_CreatesFileLogger()
    {
        var logger = FileLogger.CreateLogger<FileLoggerConfiguration>(new FileLoggerConfiguration("Path", nameof(FileLoggerTests)));
        FileInfo file = new("Path");

        Assert.Equal(file.FullName, logger.FilePath);
        Assert.IsType<FileLogger>(logger);
        Assert.Equal(nameof(FileLoggerTests), logger.LogSource);

    }

    //TODO: In CreateLogger method in FileLogger it checks if logggerConfiguration is of type FileLoggerConfiguration
    //But no tests to exits to make sure the behavior is checked.


    //TODO: I remember Mark and Benjiman saying that having conditional logic in tests was bad
    //so maybe this would need to be changed to make sure it didn't do this
    [Fact]
    public async Task Log_Message_FileAppended()
    {
        Logger.Log(LogLevel.Error, "Message1");
        Logger.Log(LogLevel.Error, "Message2");

        string[] lines = await File.ReadAllLinesAsync(FilePath);
        Assert.True(lines is [..] and { Length: 2 });
        foreach (string[] line in lines.Select(line => line.Split(',', 4)))
        {
            if (line is [string dateTime, string source, string levelText, string message])
            {
                Assert.True(DateTime.TryParse(dateTime, out _));
                Assert.Equal(nameof(FileLoggerTests), source);
                Assert.True(Enum.TryParse(typeof(LogLevel), levelText, out object? level) ?
                    level is LogLevel.Error : false,"Level was not parsed successfully.");
            }
        }
    }
}
