using System;
using System.Threading;

namespace Logger;

public class LogFactory
{
    private string _PathName;

    public LogFactory(string? filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        _PathName = filePath;
    }
    public BaseLogger? CreateLogger(string className)
    {
        if(className == nameof(FileLogger)){
            FileLogger fileLogger = new(_PathName) {ClassName = className};
            return fileLogger;
        }

        return null;
    }
    public string ConfigureFileLogger(string pathName)
        {
            _PathName = pathName;
            return _PathName;
        }
}
