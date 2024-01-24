using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger;

public class FileLogger : BaseLogger
{
    private readonly string _filePath;
    public FileLogger(string filePath)
    {
        this._filePath = filePath;
        ClassName = nameof(FileLogger);
    }
    public override void Log(LogLevel logLevel, string message)
    {
        string logEntry = $"{DateTime.Now} {ClassName} {logLevel}: {message}";

        File.AppendAllText(_filePath, logEntry + Environment.NewLine);
    }
}
