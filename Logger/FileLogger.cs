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
        // string dateTime = System.DateTime.Now.ToString("M/d/yyyy hh:mm:ss tt");
        string logEntry = $"{System.DateTime.Now} {"FileLoggerTests"} {logLevel}: {message}";
        //StreamWriter sw;
        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(logEntry);
            }
            //sw = File.CreateText(filePath);
            //sw.Dispose();
        }else if (File.Exists(filePath)) 
        {
            File.Delete(filePath);
            //File.AppendAllText(filePath, logEntry.TrimEnd());
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(logEntry);
            }
        }

        
    }
    //public (FileLogger(string logSource, string filePath))
    //using StreamWritier sw = FileLogger.AppendText(logEntry);
    //public string FilePath { get; }
    //public FileInfo FIle { get; }
    //public className {get;}

}