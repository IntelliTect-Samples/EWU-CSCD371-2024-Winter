﻿using System;
#nullable enable
namespace Logger
{
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

        private static void LogWithLevel(BaseLogger logger, LogLevel logLevel, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger), "BaseLogger parameter cannot be null.");
            }

            string className = nameof(BaseLogger);
            string formattedMessage = string.Format(message, args);
            logger.Log(logLevel, $"{className} {logLevel}: {formattedMessage}");
        }
    }

}
