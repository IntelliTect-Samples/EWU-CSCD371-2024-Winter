using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger;

public class FileLogger : BaseLogger
{
    private readonly string _Path;
    public FileLogger(string filePath)
    {
        this._Path = filePath;
    }
    public override void Log(LogLevel LogLevel, String Message)
    {
        DateTime DateTime = DateTime.Now;
        string ClassName = this.ClassName ?? "Wrong or Null name ?";
        string message = $"{DateTime} {ClassName} {LogLevel} : {Message}";
        File.AppendAllText(_Path, message + Environment.NewLine);
    }
}
