namespace Logger;

public abstract class BaseLogger
{
    //Ethan Guerin
    public string? ClassName { get; set; }
    public abstract void Log(LogLevel logLevel, string message);
}

