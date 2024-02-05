namespace Logger;
//TODO: I don't know if this is by design but because of FileLogger's constructor is public
//but its using it create a FileLogger isntead of using FileLogger's own create logger method.
//Maybe storing a Configuration proprety and then saving ti could be better for creating loggers
public class LogFactory
{
    public string? FileName { get; set; }

    public BaseLogger? CreateLogger(string className) => 
        FileName is null ? null : new FileLogger(className, FileName);

    public void ConfigureFileLogger(string fileName) => FileName=fileName;
}
