using IntelliTect.TestTools.Console;

namespace Calculate.Tests;

public class ProgramTests
{
    [Fact]
    public void Program_ValidExpression_VerifiesConsole()
    {
        ConsoleAssert.Expect("Testing WriteLine",
            () =>
            {
                Program program = new();
                program.WriteLine("Testing WriteLine");
                var result = program.ReadLine();
                Assert.NotNull(result);
            });
    }
}
