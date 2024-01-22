using System.IO;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error (this BaseLogger logger, string message, params object[] args)
    {
        LogWithLevel(logger, LogLevel.Error, message, args)
    }

   

}
