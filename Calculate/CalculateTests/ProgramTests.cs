using Calculate;
using Xunit;
using System.IO;

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

    [Theory]
    [InlineData("Test input")]
    [InlineData("More input")]
    public void TestReadLine_ValidInput_Success(string input)
    {
        Program program = new();
        Console.SetIn(new StringReader(input));

        string? actualInput = program.ReadLine();
        Assert.Equal(input, actualInput);
    }

    [Fact]
    public void TestReadLine_NoInput_ReturnsNull()
    {
        Program program = new();
        Console.SetIn(new StringReader(""));
        string? actualInput = program.ReadLine();
        Assert.Null(actualInput);
    }
}
