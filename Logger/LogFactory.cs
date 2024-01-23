namespace Logger;

public class LogFactory
{
    private string? _loggerPath;

    public BaseLogger? CreateLogger (string className)
    {
        if (className == nameof(FileLogger))
        {
            FileLogger FileLogger = new(_loggerPath!) { ClassName = className };
            return FileLogger;
        } else
        {
            return null;
        }
    }
    public void ConfigureFileLogger(string FilePath)
    {
        this._loggerPath = FilePath;
    }
    public string GetFileName()
    {
        return _loggerPath!;
    }
}
