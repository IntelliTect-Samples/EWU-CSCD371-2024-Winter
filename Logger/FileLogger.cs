namespace Logger;
using System;
using System.IO;
using System.Globalization;

public class FileLogger (string? fileName) : BaseLogger
{
    private string FilePath { get; set; } = fileName;

    private readonly string? filePath = fileName;

    public override void Log(LogLevel logLevel, string message)
    {
        if (filePath == null)
        {
            throw new ArgumentNullException(nameof(logLevel), " File path can not be null");
        }
        DateTime date = DateTime.Now;
        string currentDate = date.ToString("MM-dd-yyyy HH:mm:ss tt", CultureInfo.CurrentCulture);
        string m = $"{currentDate} {nameof(FileLogger)} {logLevel}: {message}";
        File.AppendAllText(path: filePath, contents: m + Environment.NewLine + message);
    }

}

