namespace Logger;

public class LogFactory
{
    string filePath;

    public BaseLogger CreateLogger(string className)
    {

        return new FileLogger{ClassName = className};
    }
    
    //enviorment.getcurrentdirctory

}
