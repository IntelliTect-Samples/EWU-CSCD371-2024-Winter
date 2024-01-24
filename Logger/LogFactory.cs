using System;

namespace Logger;

public class LogFactory
{
    private string? fileLoggerPath;

    public void ConfigureFileLogger(string filePath)
    {
        this.fileLoggerPath = filePath;
    }
    public BaseLogger? CreateLogger(string className)
    {
        
        ArgumentNullException.ThrowIfNull(nameof(fileLoggerPath));
           
       
        var fileLogger = new FileLogger(fileLoggerPath!)
        {
            ClassName = className
        };
        return fileLogger;
        
    }
}
