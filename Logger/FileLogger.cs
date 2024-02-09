namespace Logger;
//TODO: The in part of the CreateLogger method could be removed. I think this is because that means the loggerConfiguration is
//contravarient. So it could specify less derrived class of ILogConfiguration except ILogConfiguration doesn't have any.
//If you supply a ILogConfiguration type then it would break since it doesn't have the proper propreties to create a
//FileLogger
public class FileLogger : BaseLogger, ILogger<FileLogger>
{
    private FileInfo File { get; }

    public string FilePath { get => File.FullName; }

    public FileLogger(string logSource, string filePath) : base(logSource) => File = new FileInfo(filePath);
    //TODO making this constructor public will allow people to call this one instead of
    //The other one which checks for null configuration. Making this private makes it so they have to use other one
    public FileLogger(FileLoggerConfiguration configuration) : this(configuration.LogSource, configuration.FilePath) { }

    public static ILogger<FileLogger> CreateLogger(in ILoggerConfiguration logggerConfiguration) =>
        logggerConfiguration is FileLoggerConfiguration configuration
            ? CreateLogger(configuration)
            : throw new ArgumentException("Invalid configuration type", nameof(logggerConfiguration));

    public static FileLogger CreateLogger(FileLoggerConfiguration configuration) => new(configuration);

    public override void Log(LogLevel logLevel, string message)
    {
        using StreamWriter writer = File.AppendText();
        writer.WriteLine($"{DateTime.Now},{LogSource},{logLevel},{message}");
    }
}
