using Xunit;

namespace Logger.Tests;

public class LogFactoryTests : FileLoggerTestsBase
{
    [Fact]
    public void ConfigureFileLogger_GivenFilePath_ReturnsFileLoggerWithSetFilePath()
    {
        LogFactory logFactory = new();
        logFactory.ConfigureFileLogger(FilePath);

        // TODO: This test still needs its Assert. After FilePath is configure in the abuve code, shouldn't it then
        // then use CreateFileLogger from LogFactory to create a FileLogger, and then make sure the FilePath matches?
    }

    // TODO: There should also be a test that checks for when no FilePath has been configured the factory will return null
}
