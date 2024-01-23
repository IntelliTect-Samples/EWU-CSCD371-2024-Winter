using System;
using System.Globalization;
using System.Linq;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

            logger.Log(LogLevel.Error, string.Format(CultureInfo.InvariantCulture, message, arguments));

    }

    public static void Warning(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");


            logger.Log(LogLevel.Warning, string.Format(CultureInfo.InvariantCulture, message, arguments));
    }

    public static void Information(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

            logger.Log(LogLevel.Information, string.Format(CultureInfo.InvariantCulture, message, arguments));
     
    }
    public static void Debug(BaseLogger? logger, string message, params string[] arguments)
    {
        if (logger == null)
            throw new ArgumentNullException(nameof(logger), "Logger is null");

            logger.Log(LogLevel.Debug, string.Format(CultureInfo.InvariantCulture, message, arguments));
    }
}
