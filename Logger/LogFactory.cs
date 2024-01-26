namespace Logger;

public class LogFactory
{
    private string? filePath;

    //public FileName { get; private set; };

    public BaseLogger? CreateLogger(string className)
    {
        ConfigureFileLogger(filePath);
        if(filePath == null)
        {
            return null;
        }
        else 
        {
            FileLogger fileLogger = new (filePath) { ClassName = className};
            return fileLogger;
        }
        
    }
    
    public void ConfigureFileLogger(string? newFilePath)
    {
        if (newFilePath != null)
        {
            this.filePath = newFilePath;
        }
        
    }
    //enviorment.getcurrentdirctory

}
