using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(string message, BaseLogger? baseLogger, params string?[] args)
    {
        if (baseLogger is null)
        {
            throw new ArgumentNullException($"{baseLogger} is a null argument");
        }
        if (args is null)
        {
            baseLogger.Log(LogLevel.Error, message);
        }

        #pragma warning disable CS8604 // This will not be null since the statment above handles it
        string fullMessage = $"{message} {string.Join(" ", args)}";
        #pragma warning restore CS8604 
        baseLogger.Log(LogLevel.Error, fullMessage);
    }

    public static void Warning(string message, BaseLogger? baseLogger, params string[] args)
    {
        if (baseLogger is null)
        {
            throw new ArgumentNullException($"{baseLogger} is a null argument");
        }
        if (args is null)
        {
            baseLogger.Log(LogLevel.Warning, message);
        }
        #pragma warning disable CS8604 // This will not be null since the statment above handles it
        string fullMessage = $"{message} {string.Join(" ", args)}";
        #pragma warning restore CS8604 
        baseLogger.Log(LogLevel.Warning, fullMessage);
    }

    public static void Information(string message, BaseLogger? baseLogger, params string[] args)
    {
        if (baseLogger is null)
        {
            throw new ArgumentNullException($"{baseLogger} is a null argument");
        }
        if (args is null)
        {
            baseLogger.Log(LogLevel.Information, message);
        }
        #pragma warning disable CS8604 // This will not be null since the statment above handles it
        string fullMessage = $"{message} {string.Join(" ", args)}";
        #pragma warning restore CS8604 
        baseLogger.Log(LogLevel.Information, fullMessage);
    }

    public static void Debug(string message, BaseLogger? baseLogger, params string[] args)
    {
        if (baseLogger is null)
        {
            throw new ArgumentNullException($"{baseLogger} is a null argument");
        }
        if (args is null)
        {
            baseLogger.Log(LogLevel.Debug, message);
        }
        #pragma warning disable CS8604 // This will not be null since the statment above handles it
        string fullMessage = $"{message} {string.Join(" ", args)}";
        #pragma warning restore CS8604 
        baseLogger.Log(LogLevel.Debug, fullMessage);
    }
}
