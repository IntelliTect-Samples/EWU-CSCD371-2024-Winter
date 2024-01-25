using System;
using System.Globalization;
using System.IO;

namespace Logger;

    public class FileLogger : BaseLogger
    {

        public string PathName {  get; set; } 

        public FileLogger(string pathName)
        {
            PathName = pathName;
        }

        public override void Log(LogLevel logLevel, string message)
        {

            using StreamWriter streamWrite = File.AppendText(PathName);

            string log = $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)} ClassName logLevel.ToString(): {message}";

            streamWrite.WriteLine(log);
            streamWrite.Close();
        }
    }
