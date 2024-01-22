namespace Logger;

public class LogFactory
{
    //Private member for file path storage ie FileLogger
    private string fileLoggerFilePath;

    //Method to set file path for FileLogger
    public void ConfigureFileLogger(string filePath)
    {  
        fileLoggerFilePath = filePath; 
    }
    public BaseLogger CreateLogger(string className)
    {   //Check if confifgured 
        if (!string.IsNullOrEmpty(fileLoggerFilePath))
        {
            //Create FileLoger and set class name
            return new FileLogger(fileLoggerFilePath) { ClassName = className };
        }

        return null;
        
    }
}