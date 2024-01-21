using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

using static System.Net.Mime.MediaTypeNames;

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        public string PathName {  get; set; } 

        public FileLogger(string pathName)
        {
            PathName = pathName;
        }

        public override void Log(LogLevel logLevel, string message)
        {

            using StreamWriter streamWrite = File.CreateText(PathName);

            string log = DateTime.Now.ToString() + " " + nameof(this.ClassName) + " "
                + logLevel.ToString() + ": " + message;

            streamWrite.Write(log);

        }
    }
}
