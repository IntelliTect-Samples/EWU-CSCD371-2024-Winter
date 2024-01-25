using System;

namespace Logger;

public class LogFactory
{
    private string? _file;
    public BaseLogger? CreateLogger(string className)
    {

        if (className == nameof(FileLogger))
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
        throw new ArgumentNullException(_file, "File Path not set");
    }
}
