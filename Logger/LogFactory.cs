﻿using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace Logger;

public class LogFactory

{
    private string? filePath;


    public BaseLogger CreateLogger(string className)
    { 
        FileLogger logger = new FileLogger(filePath??"Unknown Filepath{filepath}"){ClassName = className};
        return logger;
    }

   

    public void ConfigureFileLogger(string filePath)
    {
        this.filePath = filePath;
    }
}
