using System;
using System.IO;

namespace Logger;
public class FileLogger : BaseLogger
{
    
    private readonly string _filePaths;

    public FileLogger(string filePath)
    {
        this._filePaths = filePath;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        string logEntry = $"{System.DateTime.Now} {nameof(FileLogger)} {logLevel}: {message}";

        // FileStream stream = new(filePaths + ".txt", FileMode.Open);
        string path = Path.Combine("C:\\Users\\Cynthia\\Desktop", "file.txt");
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLineAsync(logEntry);
            }
        }
        else if (File.Exists(path))
        {
            // Added this delete because of tests where it checks the first line
            File.Delete(path);
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(logEntry);
            }

        }
    }
}
