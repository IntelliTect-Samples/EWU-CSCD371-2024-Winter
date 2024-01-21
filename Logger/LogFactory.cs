namespace Logger;

public class LogFactory
{
    public BaseLogger CreateLogger(string className)
    {

        return new FileLogger{className = className};
    }
}
