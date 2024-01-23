namespace Logger;
#nullable enable

public static class BaseLoggerMixins
{

    public static void Error(this BaseLogger? logger, string message, params object[] arguments)
    {
        //check if null if so throw error
        if(logger is null)
        {
            throw new System.ArgumentNullException(nameof(logger));
        }
        
        //format string to return, use string.format so the argument is placed into the {0} spot
        string formattedString = string.Format(message, arguments);
        
        //Call log with specified loglevel for method and string
        logger.Log(LogLevel.Error, formattedString);
    }

    
    public static void Warning(this BaseLogger? logger, string message, params object[] arguments)
    {
        if(logger is null)
        {
            throw new System.ArgumentNullException(nameof(logger));
        }
        
        string formattedString = string.Format(message, arguments);
    
        logger.Log(LogLevel.Warning, formattedString); 
    }


    public static void Information(this BaseLogger? logger, string message, params object[] arguments)
    {
        if(logger is null)
        {
            throw new System.ArgumentNullException(nameof(logger));
        }
        
        string formattedString = string.Format(message, arguments);
        
        logger.Log(LogLevel.Information, formattedString);
    }


    public static void Debug(this BaseLogger? logger, string message, params object[] arguments)
    {
        if(logger is null)
        {
            throw new System.ArgumentNullException(nameof(logger));
        }
        
        string formattedString = string.Format(message, arguments);
        
        logger.Log(LogLevel.Debug, formattedString);
    }
}