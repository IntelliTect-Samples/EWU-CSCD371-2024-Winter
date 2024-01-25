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
    public override void Log(LogLevel logLevel, String message)
    {
        DateTime DateTime = DateTime.Now;
        string ClassName = this.ClassName ?? "Wrong or Null name ?";
        string MessageAppendedToFile = $"{DateTime} {ClassName} {logLevel} : {message}";
        File.AppendAllText(_Path, MessageAppendedToFile + Environment.NewLine);
    }
}
