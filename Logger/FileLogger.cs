using System;
using System.IO;


namespace Logger;

public class FileLogger(string filePath) : BaseLogger
{
    private string FilePath { get; set; } = filePath;

    public override void Log(LogLevel logLevel, string message)
    {
        File.AppendAllText(FilePath, $"{DateTime.Now} {nameof(FileLogger)} {logLevel}: {message}");
    }
}
