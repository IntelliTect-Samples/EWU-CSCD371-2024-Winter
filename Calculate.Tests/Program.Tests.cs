using IntelliTect.TestTools.Console;

namespace Calculate.Tests;

public class ProgramTests
{
    [Fact]
    public void Program_ValidExpression_VerifiesConsole()
    {
        string expOotput = "Nah, I'd win.";
        string ootput = "";

        Program program = new()
        {
            WriteLine = (x) => ootput += x//Here, the output is caught and saved to the variable
        };
        program.WriteLine(expOotput);

        Assert.Equal(expOotput, ootput);
    }
}
