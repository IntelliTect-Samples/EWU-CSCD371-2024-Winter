using Xunit;

namespace Calculate.Tests;

public class ProgramTests : IDisposable
{

    // Will never be null as it is set in constructor
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public static string TempPath { get; set; }
    public static Program DefaultProgram { get; set; }
    public static Program InitProgram { get; set; }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public ProgramTests()
    {
        TempPath = Path.GetTempFileName();
        DefaultProgram = new Program();
        InitProgram = new Program()
        {
            ReadLine = FileReadLine,
            WriteLine = FileWriteLine
        };    
    }

    static void FileWriteLine(string value)
    {
        using StreamWriter streamWriter = new(TempPath,true);
        streamWriter.WriteLine(value);
        streamWriter.Close();
    }
    static string? FileReadLine()
    {
        using StreamReader streamReader = new(TempPath);
        return streamReader.ReadLine();

    }

    [Fact]
    public void DefaultConstructor_WriteLineProperty_ExpectedBehaviour()
    {
        using StringWriter mockConsole = new();

        Console.SetOut(mockConsole);
        DefaultProgram.WriteLine("Hello");
        DefaultProgram.WriteLine("World");

        Assert.Contains("Hello", mockConsole.ToString());
        Assert.Contains("World", mockConsole.ToString());

    }

    [Fact]
    public void DefaultConstructor_ReadLineProperty_ExpectedBehaviour()
    {
        Console.SetIn(new StringReader(string.Join(Environment.NewLine, ["Hello", "World"])));

        Assert.Equal("Hello", DefaultProgram.ReadLine());
        Assert.Equal("World", DefaultProgram.ReadLine());

    }

    [Fact]
    public void Constructor_InitFileWriteLine_ExpectedBehavior()
    {
        InitProgram.WriteLine("Testing File Writing");
        InitProgram.WriteLine("Testing File Writing 2");

        using StreamReader streamReader = new(TempPath);
        Assert.Equal("Testing File Writing", streamReader.ReadLine());
        Assert.Equal("Testing File Writing 2", streamReader.ReadLine());

    }
    [Fact]
    public void Constructor_InitFileReadLine_ExpectedBehavior()
    {
        using StreamWriter streamWriter = new(TempPath);
        streamWriter.WriteLine("Testing File Reading");
        streamWriter.WriteLine("Testing File Reading 2");

        streamWriter.Close();

        Assert.Equal("Testing File Reading", InitProgram.ReadLine());
        Assert.Equal("Testing File Reading", InitProgram.ReadLine());

    }

    public void Dispose()
    {
        if (File.Exists(TempPath))
        {
            File.Delete(TempPath);
            GC.SuppressFinalize(this);
        }
    }
}


