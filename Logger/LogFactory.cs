using System.Dynamic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Logger;

public class LogFactory

{
    private string? _filePaths;



    public BaseLogger? CreateLogger(string className)
    {
        if (_filePaths == null)
        {
            return null;
        }
        else
        {
            ConfigureFileLogger(_filePaths);
            FileLogger logger = new (_filePaths!) { ClassName = className };
            return logger;
        }

    }

   

    public void ConfigureFileLogger(string filePath)
    {
        this._filePaths = filePath;
    }
}
