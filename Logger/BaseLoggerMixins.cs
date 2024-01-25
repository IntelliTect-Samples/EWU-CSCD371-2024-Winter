using System;
using System.Dynamic;
using System.Globalization;
namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger? logger, string message, params object[] parms)
    {
        LogInstructions(logger, LogLevel.Error, message, parms);
    }

    public static void Warning(this BaseLogger? logger, string message, params object[] parms)
    {
        LogInstructions(logger, LogLevel.Warning, message, parms);
    }

    public static void Information(this BaseLogger? logger, string message, params object[] parms)
    {
        LogInstructions(logger, LogLevel.Information, message, parms);
    }

    public static void Debug(this BaseLogger? logger, string message, params object[] parms)
    {
        LogInstructions(logger, LogLevel.Debug, message, parms);
    }


    public static void LogInstructions(this BaseLogger? logger, LogLevel level, string message, params object[] yo)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger cant be null");
        }
        string output = string.Format(CultureInfo.InvariantCulture, message, yo);


        logger.Log(level, output);
    }

}