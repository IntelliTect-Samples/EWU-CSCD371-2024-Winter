using System;
using System.IO;


namespace Logger;

public class FileLogger(string file) : BaseLogger
{
    private string _file { get; set; } = file;

    public override void Log(LogLevel logLevel, string message)
    {
        File.AppendAllText(_file, $"{DateTime.Now} {nameof(FileLogger)} {logLevel}: {message}");
    }
}