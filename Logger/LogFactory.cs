namespace Logger;
using System;
#nullable enable

public class LogFactory
{
    private string? logPath;
    public string configure(string logPath)
    {
        if (logPath == null)
        {
            throw new ArgumentNullException(nameof(logPath), " File path can not be null"); ;
        }
        else
        {
            logPath = logPath;
            return logPath;
        }
    }



    public BaseLogger? CreateLogger(string className)
    {
        if (logPath == null)
        {
            throw new ArgumentNullException(nameof(className), " File path can not be null"); ;
        }
        else
        {
            FileLogger logg = new(logPath!)
            {
                ClassName = className,

            };
            return logg;
        }
    }
}