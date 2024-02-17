namespace Calculate.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_NullParameters_ThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => Calculator.Add(null!, null!));
    }
}