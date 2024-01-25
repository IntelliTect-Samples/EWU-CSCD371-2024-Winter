namespace Logger;
using System.Globalization;
#nullable enable

public static class BaseLoggerMixins
{

    public static void Error(this BaseLogger? logger, string message, params object[] arguments)
    {
        LogGivenLevel(logger, LogLevel.Error, message, arguments);
    }

    
    public static void Warning(this BaseLogger? logger, string message, params object[] arguments)
    {
        LogGivenLevel(logger, LogLevel.Warning, message, arguments);
    }


    public static void Information(this BaseLogger? logger, string message, params object[] arguments)
    {
        LogGivenLevel(logger, LogLevel.Information, message, arguments);
    }


    public static void Debug(this BaseLogger? logger, string message, params object[] arguments)
    {
        LogGivenLevel(logger, LogLevel.Debug, message, arguments);
    }


    //Helper method 
    public static void LogGivenLevel(BaseLogger? logger, LogLevel logLevel, string message, params object[] arguments)
    {
        if(logger is null)
        {
            throw new System.ArgumentNullException(nameof(logger));
        }
        
        string formattedString = string.Format(CultureInfo.CurrentCulture, message, arguments);
        
        logger.Log(logLevel, formattedString);

    }
}