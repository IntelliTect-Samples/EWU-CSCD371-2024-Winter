﻿using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string message, params object[] args)
    {
        LogWithLevel(logger, LogLevel.Error, message, args);
    }

    public static void Warning(this BaseLogger logger, string message, params object[] args)
    {
        LogWithLevel(logger, LogLevel.Warning, message, args);
    }

    public static void Information(this BaseLogger logger, string message, params object[] args)
    {
        LogWithLevel(logger, LogLevel.Information, message, args);
    }

    public static void Debug(this BaseLogger logger, string message, params object[] args)
    {
        LogWithLevel(logger, LogLevel.Debug, message, args);
    }

    public static System.Globalization.CultureInfo CurrentCulture { get; set; }

    private static void LogWithLevel(BaseLogger logger, LogLevel logLevel, string message, params object[] args)
    {

        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
        }


        string formattedMessage = string.Format(CurrentCulture, message, args);


        logger.Log(logLevel, formattedMessage);
    }
}
