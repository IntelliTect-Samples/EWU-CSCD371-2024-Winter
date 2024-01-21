using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        string PathName {  get; set; } 

        public FileLogger(string pathName)
        {
            PathName = pathName;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }
    }
}
