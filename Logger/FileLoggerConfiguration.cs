namespace Logger;
//TODO: Could derrive from BaseLoggerConfiguration so that you don't have to do the check again for LogSource
//and define LogSource again
public class FileLoggerConfiguration : ILoggerConfiguration
{
    public FileLoggerConfiguration(string filePath, string logSource)
    {
        FilePath = string.IsNullOrWhiteSpace(filePath)
                ? throw new ArgumentException($"'{nameof(filePath)}' cannot be null or whitespace.", nameof(filePath))
                : filePath;
        LogSource = string.IsNullOrWhiteSpace(logSource)
                ? throw new ArgumentException($"'{nameof(logSource)}' cannot be null or whitespace.", nameof(logSource))
                : logSource;

    }
    
    // TODO Properties should be declared at the top of class
    public string FilePath { get;  }
    public string LogSource { get; }
}
