namespace Logger;
using System;
using System.IO;
using System.Globalization;

public class FileLogger (string? fileName) : BaseLogger
{
    private string? FilePath { get; set; } = fileName;

    private readonly string? filePath = fileName;

    public override void Log(LogLevel logLevel, string message)
    {
        if (filePath == null)
        {
            throw new ArgumentNullException(nameof(logLevel), " File path can not be null");
        }
        DateTime date = DateTime.Now;
        string currentDate = date.ToString("MM-dd-yyyy HH:mm:ss tt", CultureInfo.CurrentCulture);
        string m = $"{currentDate} {this.ClassName} {logLevel}: {message}";
<<<<<<< HEAD
=======

>>>>>>> cd4cecc722f31e5a2714f61f9bb389390f3a3645
        File.AppendAllText(path: filePath, contents: m + Environment.NewLine + message);
    }

}

