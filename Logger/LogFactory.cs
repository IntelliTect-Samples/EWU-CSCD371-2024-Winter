using System;

namespace Logger;

public class LogFactory
{

    public BaseLogger? CreateLogger(string className)
    {

        return null;
    }

    public void ConfigureFileLogger(string pathName)
    {
        throw new NotImplementedException();
    }
}
