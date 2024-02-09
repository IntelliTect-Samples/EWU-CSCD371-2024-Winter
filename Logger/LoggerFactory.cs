
namespace Logger;

public class LoggerFactory<T> where T : BaseLogger
{
    public ILogger<T>? CreateLogger<T1>(T1 configuration) where T1 : ILoggerConfiguration
    {
        if(typeof(T) == typeof(FileLogger))
        {
            if (configuration is FileLoggerConfiguration fileConfig)
            {
                return (ILogger<T>)new FileLogger(in fileConfig);

            }
            else
            {
                throw new ArgumentException("Configuration type not compatible with FileLogger type",nameof(configuration));
            }
        }
        else
        {
            // I didn't know if it'd be better to throw exception to say unsupported Logger type
            // or to just return null
            return null;
        }

    }
}
