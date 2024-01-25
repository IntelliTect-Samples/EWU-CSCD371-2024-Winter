using System;
using System.Runtime.CompilerServices;

namespace Logger;

public class LogFactory
{

    private string? _pathName; 

    public BaseLogger? CreateLogger(string className)
    {
        if (_pathName == null)
        {
            return null;
        }

        return new FileLogger(_pathName) 
        {
            ClassName = className
        };
    }

    public void ConfigureFileLogger(string pathName)
    {
        _pathName = pathName;
    }
}
