using Calculate;
using Xunit;

namespace CalculateTests;

public class ProgramTests
{
    [Fact]
    public void TestWriteLine_VaildInput_Success()
    {
        string expectedOutput = "Hello, World!";
        string actualOutput = "";
        Program program = new()
        {
            WriteLine = (s) => actualOutput = s
        };
        program.WriteLine(expectedOutput);

        Assert.Equal(expectedOutput, actualOutput);
    }

    [Fact]
    public void TestReadLine_ValidInput_Success()
    {
        Program program = new();
        String expectedInput = "Test Input";
        Console.SetIn(new System.IO.StringReader(expectedInput));

        string? actualInput = program.ReadLine();

        Assert.Equal(expectedInput, actualInput);
    }
}
