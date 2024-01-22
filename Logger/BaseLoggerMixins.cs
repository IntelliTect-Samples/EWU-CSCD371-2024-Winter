using System.IO;
using System.Net.NetworkInformation;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error (this BaseLogger logger, string message, params object[] args)
    {
        LogWithLevel(logger, LogLevel.Error, message, args)
    }

   public static void Warning (this BaseLogger logger, string message, params object[] args)
    {
        LogWithLevel(logger, LogLevel.Warning, message, args)
    }


}
