#nullable enable
namespace Logger;

public class LogFactory
{
    private string? PathToFile;
    public void ConfigureFileLogger(string pathToFile)
    {
        PathToFile = pathToFile;
    }
    public BaseLogger? CreateLogger(string className)
    {
        if (PathToFile is null)
        {
            return null;
        }

        else
        {
            BaseLogger baseLogger = new FileLogger(PathToFile)
            {
                ClassName = className
            };
            return baseLogger;
        }
    }
}
