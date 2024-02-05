using Xunit;

namespace Logger.Tests;
public class LogFactoryTests : FileLoggerTestsBase
{
    // TODO: This test is incomplete. It should then call createLogger method and then assert that the BaseLogger
    // Returned is not null and also that it's logSourse matches LogFactoryTests and FilePath is correct
    [Fact]
    public void ConfigureFileLogger_GivenFilePath_ReturnsFileLoggerWithSetFilePath()
    {
        LogFactory logFactory = new();
        logFactory.ConfigureFileLogger(FilePath);
    }

    //TODO: Missing test for if ConfigureFileLogger isn't set which would return a null value
}
