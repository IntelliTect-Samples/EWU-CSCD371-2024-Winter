using System;
using System.Threading;

namespace Logger;

public class LogFactory
{
    private string? _PathName;

    public string PathName
    {
        get => _PathName!;
        set
        {
            _PathName = value;
        }
    }

    public BaseLogger? CreateLogger(string className)
    {

        if(_PathName != null)
        {
            FileLogger fileLogger = new(_PathName) { ClassName = className };
            return fileLogger;
        }

        return null;
    }
    public string ConfigureFileLogger(string pathName)
    {
        PathName = pathName;
        return PathName;
    }
}
