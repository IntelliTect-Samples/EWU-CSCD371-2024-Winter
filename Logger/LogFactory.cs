namespace Logger;
//Ethan Guerin

public class LogFactory
{
    private string? fileLoggerPath;

    public void ConfigureFileLogger(string filePath)
    {
        this.fileLoggerPath = filePath;
    }
    public BaseLogger? CreateLogger(string className)
    {
        if(fileLoggerPath != null) {
            var fileLogger = new FileLogger(fileLoggerPath);
            fileLogger.ClassName = className;
            return fileLogger;
        }
        return null;
    }
}
