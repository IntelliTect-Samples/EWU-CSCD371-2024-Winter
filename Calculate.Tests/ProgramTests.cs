using Xunit;

namespace Calculate.Tests;

public class ProgramTests
{
    [Fact]
    public void WriteLine_OutputMatch_True()
    {
        string input = "Here is my string and nothing else";
        MockClass mockClass = new();
        Program program = new()
        {
            WriteLine = mockClass.WriteLine,
        };

        program.WriteLine(input);

        Assert.Equal(input, mockClass.Output);

    }

    [Fact]
    public void ReadLine_OutputMatch_Ture()
    {
        string input = "Input? Again?";
        MockClass mockClass = new();
        Program program = new()
        {
            WriteLine = mockClass.WriteLine,
            ReadLine = mockClass.ReadLine,
        };
        mockClass.Output = input;
        Assert.Equal(input, program.ReadLine());

    }
}

public class MockClass
{
    public string Output { get; set; }
    public void WriteLine(string input)
    {
        Output = input;
    }

    public string ReadLine()
    {
        return Output;
    }
}
