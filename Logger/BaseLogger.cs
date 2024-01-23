namespace Logger;

public abstract class BaseLogger
{
    public abstract void Log(LogLevel LogLevel, string Message);

    public string? ClassName { get; set; }
}

