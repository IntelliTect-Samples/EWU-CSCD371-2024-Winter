using System;
using System.Linq;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

        if (arguments == null)
        {
            logger.Log(LogLevel.Error, message);

        }
        else
        {
            string argumentsAsString = string.Join(" ", arguments);
            string combinedMessage = message + " " + argumentsAsString;
            logger.Log(LogLevel.Error, combinedMessage);

        }


    }

    public static void Warning(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

        if (arguments == null)
        {
            logger.Log(LogLevel.Warning, message);
        }
        else
        {
            string argumentsAsString = string.Join(" ", arguments);
            string combinedMessage = message + " " + argumentsAsString;
            logger.Log(LogLevel.Warning, combinedMessage);

        }
    }

    public static void Information(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

        if (arguments == null)
        {
            logger.Log(LogLevel.Information, message);
        }
        else
        {
            string argumentsAsString = string.Join(" ", arguments);
            string combinedMessage = message + " " + argumentsAsString;
            logger.Log(LogLevel.Information, combinedMessage);
        }
    }
    public static void Debug(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

        if (arguments == null)
        {
            logger.Log(LogLevel.Debug, message);
        }
        else
        {
            string argumentsAsString = string.Join(" ", arguments);
            string combinedMessage = message + " " + argumentsAsString;
            logger.Log(LogLevel.Debug, combinedMessage);
        }
    }
}
