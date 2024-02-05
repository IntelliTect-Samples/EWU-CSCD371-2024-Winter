namespace Logger;

public interface ILogger<T> where T : BaseLogger
{
    string LogSource { get; } // Many of you refer to this as the ClassName.
    void Log(LogLevel logLevel, string message);

    // While interesting, this is probably better implemented using a factory class.
    // because you can't have static abstract members on classes
    // and you can't have covariant return types on interface members. :(
    static abstract T CreateLogger<T2>(in T2 configuration) where T2 : ILoggerConfiguration;
}
