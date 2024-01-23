using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        //Private mem to store file path
        private readonly string filePath;

        //Constructor
        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            //Include logic here, to comply with assignment instructions of date/time, class name, log level, and message.
            string logEntry = $"{DateTime.Now} {ClassName} {logLevel}: {message}";

            //Append log entry 
            File.AppendAllText(filePath, logEntry + Environment.NewLine);
        }
    }
}