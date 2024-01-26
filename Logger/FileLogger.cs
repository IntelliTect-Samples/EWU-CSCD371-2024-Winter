using System;
using System.IO;

namespace Logger;

public class FileLogger : BaseLogger
{
    public string PathToFile { get; set; }

    public FileLogger(string pathToFile)
    {
        PathToFile = pathToFile;
    }

    override public void Log(LogLevel logLevel, string message)
    {
        string currentDateAndTime = DateTime.Now.ToString("MM/d/yyy hh:mm:ss tt");
        string className = this.ClassName ?? "Wrong or Null name";
        string OutputToLog = $"{currentDateAndTime} {className} {logLevel} : {message}";
        File.AppendAllText(PathToFile, OutputToLog);
    }
}
