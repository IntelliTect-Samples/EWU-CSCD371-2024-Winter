namespace Logger;

public class FileLogger : BaseLogger
{

    string filePath;
    public FileLogger(string filePath)
    {
        this.filePath = filePath;
    }
    public override void Log(LogLevel logLevel, string message)
    {
        string dateTime = System.DateTime.Now.ToString("M/d/yyyy hh:mm:ss tt");
        string logEntry = $"{dateTime} {nameof(ClassName)} {logLevel}: {message}";

        //File.AppendAllText(filePath, logEntry + Environment.NewLine);
        //need to append and write to file
    }
}