using System;
using System.Linq;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

        if (arguments.Length == 0)
        {
            logger.Log(LogLevel.Error, message);

        }
        else
        {
            logger.Log(LogLevel.Error, string.Format(message, arguments));
        }


    }

    public static void Warning(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

        if (arguments.Length == 0)
        {
            logger.Log(LogLevel.Warning, message);
        }
        else
        {
            logger.Log(LogLevel.Warning, string.Format(message, arguments));
        }
    }

    public static void Information(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

        if (arguments.Length == 0)
        {
            logger.Log(LogLevel.Information, message);
        }
        else
        {
            logger.Log(LogLevel.Information, string.Format(message, arguments));
        }
    }
    public static void Debug(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

        if (arguments.Length == 0)
        {
            logger.Log(LogLevel.Debug, message);
        }
        else
        {
            logger.Log(LogLevel.Debug, string.Format(message, arguments));
        }
    }
}
