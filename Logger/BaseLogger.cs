using System;
using System.IO;

namespace Logger;
#nullable enable

public abstract class BaseLogger
{
    //Auto Property
    public string? ClassName { get; set; }

    public abstract void Log(LogLevel logLevel, string message);
}


//FileLogger || Implementation of BaseLogger
public class FileLogger : BaseLogger
{
    // create initializer for FileLogger
    public string _fileName;
    public FileLogger(string fileName)
    {
        _fileName = fileName;
    }

    //current date/time 
    string dateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");

    //create variable for class name 
    string className = nameof(FileLogger);

    public override void Log(LogLevel logLevel, string message)
    {
        //format strings to append to file
        string logAppend = $"{dateTime} {className} {logLevel}: {message}";

        //append string
        File.AppendAllText(_fileName, logAppend);
    }

}