namespace Logger;

public class FileLogger : BaseLogger, ILogger<FileLogger>
{
    private FileInfo File { get; }

    public string FilePath { get => File.FullName; }

    public FileLogger(string logSource, string filePath) : base(logSource) => File = new FileInfo(filePath);

    public FileLogger(FileLoggerConfiguration configuration) : this(configuration.LogSource, configuration.FilePath) {}

    static FileLogger ILogger<FileLogger>.CreateLogger(in ILoggerConfiguration logggerConfiguration) => 
        logggerConfiguration is FileLoggerConfiguration configuration
            ? CreateLogger(configuration)
            : throw new ArgumentException("Invalid configuration type", nameof(logggerConfiguration));

    public static FileLogger CreateLogger(FileLoggerConfiguration configuration) => new(configuration);

    public override void Log(LogLevel logLevel, string message)
    {
        using StreamWriter writer = File.AppendText();
        writer.WriteLine($"{ DateTime.Now },{LogSource},{logLevel},{message}");
    }
}
