using System;
using System.IO;

namespace Logger;

public class FileLogger : BaseLogger
{

    private readonly string filePath;
    public FileLogger(string filePath)
    {
        this.filePath = filePath;
    }
    public override void Log(LogLevel logLevel, string message)
    {
        string dateTime = System.DateTime.Now.ToString("M/d/yyyy hh:mm:ss tt");
        string logEntry = $"{dateTime} {nameof(this.ClassName)} {logLevel}: {message}";

        if (!File.Exists(filePath))
        {
            StreamWriter sw = File.CreateText(filePath);

        }

        
        File.AppendAllText(filePath, logEntry + Environment.NewLine);
        
    }
}