namespace Logger;
#nullable enable

public class LogFactory
{
    //create nullable path string
    private string? path;   

    //Configure given filePath as path
    public string ConfigureFileLogger(string filePath)
    {
        path = filePath;

        return path;
    }

    //Creates Logger
    public BaseLogger? createLogger()
    {
        //If given null path return null
        if(path == null)
        {
            return null;
        }

        //If its not null then create new FileLogger and set class name and return the logger
        else
        {
            FileLogger fileLogger = new(ConfigureFileLogger(path));

            return fileLogger;
        }
    }
}