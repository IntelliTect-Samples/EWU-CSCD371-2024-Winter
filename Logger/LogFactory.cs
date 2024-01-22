namespace Logger;

public class LogFactory : BaseLogger
{
    string filePath;

    public BaseLogger CreateLogger(string className)
    {

        return new FileLogger{ClassName = className};
    }
    

}
