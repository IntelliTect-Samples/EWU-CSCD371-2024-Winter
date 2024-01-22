namespace Logger;

public class LogFactory
{
    private string filePath;

    public BaseLogger? CreateLogger(string className)
    {
        ConfigureFileLogger(filePath);
        if(filePath == null)
        {
            return null;
        }
        else 
        {
            FileLogger fileLogger = new FileLogger(filePath) { ClassName = className};
            return fileLogger;
        }
        
    }
    
    public void ConfigureFileLogger(string filePath)
    {
        this.filePath = filePath;
    }
    //enviorment.getcurrentdirctory

}
