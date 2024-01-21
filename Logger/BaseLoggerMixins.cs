using System;

namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(BaseLogger? logger, string message,params string [] messages)
    {
        if(logger == null)
            throw new ArgumentNullException();
    }
}
