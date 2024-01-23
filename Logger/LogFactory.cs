namespace Logger;
#nullable enable

public class LogFactory
{
    //create nullable path string
    private string? path;   

    //Configure given filePath as path
    public void ConfigureFileLogger(string filePath)
    {
        path = filePath;
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
            BaseLogger baseLogger = new FileLogger(path)
            {
                ClassName = nameof(LogFactory)
            };

            return baseLogger;
        }
    }
}