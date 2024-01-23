using System;
using System.Runtime.CompilerServices;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(message);
        }

        if (args == null)
        {
            logger.Log(LogLevel.Error, message);
        } else
        {
            logger.Log(LogLevel.Error, string.Format(null, message, args));
        }
    }

    public static void Warning(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(message);
        }

        if (args == null)
        {
            logger.Log(LogLevel.Warning, message);
        }
        else
        {
            logger.Log(LogLevel.Warning, string.Format(null, message, args));
        }
    }
    public static void Information(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(message);
        }

        if (args == null)
        {
            logger.Log(LogLevel.Information, message);
        }
        else
        {
            logger.Log(LogLevel.Information, string.Format(null, message, args));
        }
    }
    public static void Debug(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(message);
        }

        if (args == null)
        {
            logger.Log(LogLevel.Debug, message);
        }
        else
        {
            logger.Log(LogLevel.Debug, string.Format(null, message, args));
        }
    }
}
    