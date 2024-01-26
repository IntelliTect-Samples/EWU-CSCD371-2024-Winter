using System;
using System.Runtime.CompilerServices;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? logger, string message, params object[] args)
    {
        if(logger == null)
        {
            throw new ArgumentNullException(message);
        }

        if(args == null)
        {
            logger.Log(LogLevel.Error, message);
        }
        else
        {
            
            String tempMessage = String.Format(null, message, args);
            
            logger.Log(LogLevel.Error, tempMessage);
        }

        
    }

    public static void Warning(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(message);
        }

        if(args == null)
        {
            logger.Log(LogLevel.Warning, message);
        }
        else
        {
            
            String tempMessage = String.Format(null ,message, args);
            
            logger.Log(LogLevel.Warning, tempMessage);
        }
    }

    public static void Information(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(message);
        }

       if(args == null)
        {
            logger.Log(LogLevel.Information, message);
        }
        else
        {
            
            String tempMessage = String.Format(null, message, args);
            
            logger.Log(LogLevel.Information, tempMessage);
        }
    }

    public static void Debug(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(message);
        }

        if(args == null)
        {
            logger.Log(LogLevel.Debug, message);
        }
        else
        {
            
            String tempMessage = String.Format(null, message, args);
            
            logger.Log(LogLevel.Debug, tempMessage);
        }
    }
}
