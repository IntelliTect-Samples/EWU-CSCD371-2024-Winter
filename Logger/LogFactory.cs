using System;

namespace Logger;

public class LogFactory
{
    private string? _file;
    public BaseLogger? CreateLogger(string className)
    {
        if(_file == null) 
        { 
            return null; 
        }
        else if (className == nameof(FileLogger))
        {
            FileLogger fileLogger = new(ConfigureFileLogger(_file!)) { ClassName = className };
            return fileLogger;
            
        }
        return null;
    }
    public string ConfigureFileLogger(string file)
    {
        if(!string.IsNullOrWhiteSpace(file))
        {
            _file = file;
            return _file;
        }
        _file = null;
        return "";
    }
}
