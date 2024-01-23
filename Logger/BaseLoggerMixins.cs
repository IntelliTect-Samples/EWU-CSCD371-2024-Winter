# nullable enable
﻿using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(string message, BaseLogger? baseLogger, params string[] args)
    {
        if (baseLogger is null)
        {
            throw new ArgumentNullException($"{baseLogger} is a null argument");
        }
        string fullMessage = $"{message} {string.Join(" ", args)}";
        baseLogger.Log(LogLevel.Error, fullMessage);
    }

    public static void Warning(string message, BaseLogger? baseLogger, params string[] args)
    {
        if (baseLogger is null)
        {
            throw new ArgumentNullException($"{baseLogger} is a null argument");
        }
        string messageWithArgs = $"{message} {string.Join(" ", args)}";
        baseLogger.Log(LogLevel.Warning, messageWithArgs);
    }

    public static void Information(string message, BaseLogger? baseLogger, params string[] args)
    {
        if (baseLogger is null)
        {
            throw new ArgumentNullException($"{baseLogger} is a null argument");
        }
        string messageWithArgs = $"{message} {string.Join(" ", args)}";
        baseLogger.Log(LogLevel.Information, messageWithArgs);
    }

    public static void Debug(string message, BaseLogger? baseLogger, params string[] args)
    {
        if (baseLogger is null)
        {
            throw new ArgumentNullException($"{baseLogger} is a null argument");
        }
        string messageWithArgs = $"{message} {string.Join(" ", args)}";
        baseLogger.Log(LogLevel.Debug, messageWithArgs);
    }
}
