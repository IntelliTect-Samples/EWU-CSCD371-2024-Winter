namespace Logger;

public class LogFactory
{
    private string? _file;
    public BaseLogger? CreateLogger(string className)
    {

        if (string.IsNullOrWhiteSpace(_file))
        {
            return null;
        }
        else
        {
            return new FileLogger(_file!)
            { 
                ClassName = className
            };
        }
    }
    public void ConfigureFileLogger(string file)
    {
        _file = file;
    }
}
