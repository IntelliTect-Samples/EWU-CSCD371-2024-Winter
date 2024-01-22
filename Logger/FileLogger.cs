namespace Logger;

public class FileLogger : BaseLogger
{

    string filePath;
    public FileLogger(string filePath)
    {
        this,.filePath = filePath;
    }
    public override void Log(LogLevel logLevel, string message)
    {
        throw new System.NotImplementedException();
    }
}