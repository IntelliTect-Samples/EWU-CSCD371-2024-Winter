using IntelliTect.TestTools.Console;

namespace Calculate.Tests;

public class ProgramTests
{
    [Fact]
    public void Program_ValidExpression_VerifiesConsole()
    {
        List<string> args = [];
        Action<string> fWriteLine = args.Add;
        string? fInput = "3 + 4";
        string? fReadLine() => fInput;

        Program program = new()
        {
            WriteLine = fWriteLine,
            ReadLine = fReadLine
        };

        Program.Main([]);

        Assert.Contains("Enter an expression: ", args);
        Assert.Contains("Result: 7", args);

    }
}
