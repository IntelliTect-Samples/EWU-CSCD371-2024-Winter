namespace Logger;

public abstract class BaseLogger
{
    //Auto property implementation 
    public string ClassName { get; set; }
    public abstract void Log(LogLevel logLevel, string message);
}