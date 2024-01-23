namespace Logger;
#nullable enable

public class LogFactory
{

    public string? path;   

    public void ConfigureFileLogger(string filePath)
    {
        path = filePath;
    }

    public BaseLogger? createLogger()
    {
        if(path == null)
        {
            return null;
        }

        else
        {
            BaseLogger baseLogger = new FileLogger(path)
            {
                ClassName = nameof(LogFactory)
            };

            return baseLogger;
        }
    }
}