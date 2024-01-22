namespace Logger;

public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger baseLogger, string message, params object[] arguments)
    {
        if (baseLogger == null)
        {
            throw new System .ArgumentNullException(nameof(baseLogger));
        }
        else
        {
            baseLogger.Log(LogLevel.Error, string.Format(message, arguments);
        }
    }
}
