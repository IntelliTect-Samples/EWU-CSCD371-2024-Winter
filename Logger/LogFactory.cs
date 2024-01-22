namespace Logger;

public class LogFactory
{
    private string filePath;

    public BaseLogger CreateLogger(string className)
    {

        return new FileLogger{ClassName = className};
    }
    
    public void ConfigureFileLogger(string filePath)
    {
        this.filePath = filePath;
    }
    //enviorment.getcurrentdirctory

}
