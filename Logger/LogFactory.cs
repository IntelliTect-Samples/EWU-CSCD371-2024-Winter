namespace Logger;
using System;

public class LogFactory
{
    private string? logPath = null;
    public string configure(string logPath)
    {
        if (logPath == null)
        {
            throw new ArgumentNullException(nameof(logPath), " File path can not be null"); ;
        }
        else
        {   
            this.logPath = logPath;
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
            FileLogger log = new(logPath!)
            {
                ClassName = className,

            };
            return log;
        }
    }
}