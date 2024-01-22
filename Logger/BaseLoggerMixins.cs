using System;
using System.Globalization;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger logger, string message, params object[] args)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        
        logger.Log(LogLevel.Error, string.Format(CultureInfo.InvariantCulture, message, args));   
    }

    public static void Warning(this BaseLogger logger, string message, params object[] args)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        logger.Log(LogLevel.Warning, string.Format(CultureInfo.InvariantCulture, message, args));
    }

    public static void Information(this BaseLogger logger, string message, params object[] args)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        logger.Log(LogLevel.Information, string.Format(CultureInfo.InvariantCulture, message, args));
    }

    public static void Debug(this BaseLogger logger, string message, params object[] args)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        logger.Log(LogLevel.Debug, string.Format(CultureInfo.InvariantCulture, message, args));
    }
}
