namespace Logger;

public class LogFactory
{
    private string? _pathToFile;

    public string GetFileName()
    {
        return _pathToFile!;
    }
    public void ConfigureFileLogger(string PathToFile)
    {
        this._pathToFile = PathToFile;
    }
    
    public BaseLogger? CreateLogger(string className)
    {
        if (className == nameof(FileLogger))
        {
            FileLogger fileLogger = new(_pathToFile!){
                ClassName = className
            };
            return fileLogger;
        }
        else
        {
            return null;
        }
    }
}
