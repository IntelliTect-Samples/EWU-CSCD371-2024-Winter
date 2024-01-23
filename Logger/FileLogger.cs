﻿using System;
using System.IO;


namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string FileName
        {
            get;
            set;
        }

        public string CurrentDirectory
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }
        public FileLogger(string filePath)
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.txt";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;

        }

        public override void Log(LogLevel logLevel, string message)
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            using StreamWriter writeTo = File.AppendText(this.FilePath);
            writeTo.WriteLine("{0} {1} ", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            writeTo.WriteLine("{0}", nameof(FileLogger));
            writeTo.WriteLine("{0}: ", logLevel);
            writeTo.WriteLine("{0}", message);

        }
    }
}
