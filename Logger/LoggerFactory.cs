
namespace Logger;

public class LoggerFactory<T> where T : BaseLogger
{
    public ILogger<T> CreateLogger<T1>(T1 fileLoggerConfiguration) where T1 : ILoggerConfiguration
    {
        if(typeof(T) == typeof(FileLogger))
        {
            if (fileLoggerConfiguration is FileLoggerConfiguration file)
            {
                return (ILogger<T>)new FileLogger(in file);

            }
            else
            {
                throw new ArgumentException("Configuration type not compatible with FileLogger type",nameof(fileLoggerConfiguration));
            }
        }
        return null;

    }
}
