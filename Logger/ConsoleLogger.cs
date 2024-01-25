using System;

namespace Logger.Tests;

    public class ConsoleLogger : BaseLogger
    {
        public ConsoleLogger()
        {
        }

    public override void Log(LogLevel level, string message)
    {
        throw new NotImplementedException();
    }
}
