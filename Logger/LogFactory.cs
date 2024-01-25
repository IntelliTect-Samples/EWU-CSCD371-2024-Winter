namespace Logger;
using System;

public class LogFactory
{
    private string? logPath;
    public void ConfigureFileLogger(string logPath)
<<<<<<< HEAD
=======

>>>>>>> cd4cecc722f31e5a2714f61f9bb389390f3a3645
    {
        if (logPath == null)
        {
            throw new ArgumentNullException(nameof(logPath), " File path can not be null"); ;
        }
        else
        {   
            this.logPath = logPath;
        }
    }



    public BaseLogger? CreateLogger(string className)
    {
        if (logPath == null)
        {
<<<<<<< HEAD
            return null;
=======
return null;
>>>>>>> cd4cecc722f31e5a2714f61f9bb389390f3a3645
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