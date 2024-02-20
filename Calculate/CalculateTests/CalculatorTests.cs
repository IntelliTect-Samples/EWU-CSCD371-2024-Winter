using Calculate;
using Xunit;

namespace CalculateTests;
public class CalculatorTests
{
    [Theory]
    [InlineData(3, 4, 7)]
    [InlineData(42, 2, 44)]
    [InlineData(6, 7, 13)]
    [InlineData(20, 5, 25)]
    public void TestAdd(int a, int b, int expected)
    {
        int result = Calculator.Add(a, b);

        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(3, 4, -1)]
    [InlineData(42, 2, 40)]
    [InlineData(6, 7, -1)]
    [InlineData(20, 5, 15)]
    public void TestSubtract(int a, int b, int expected)
    {
        int result = Calculator.Subtract(a, b);

        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(3, 4, 12)]
    [InlineData(42, 2, 84)]
    [InlineData(6, 7, 42)]
    [InlineData(20, 5, 100)]
    public void TestMultiply(int a, int b, int expected)
    {
        int result = Calculator.Multiply(a, b);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(40, 2, 20)]
    [InlineData(49, 7, 7)]
    [InlineData(20, 5, 4)]
    public void TestDivide(int a, int b, int expected)
    {
        int result = Calculator.Divide(a, b);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestDivide_ZeroDenominator_Throws()
    {
        Assert.Throws<ArgumentException>(() => Calculator.Divide(3, 0));
    }

    [Theory]
    [InlineData("2 + 3", 5, true)]
    [InlineData("-4 - 3", -7, true)]
    [InlineData("2", 0, false)]
    [InlineData("2+3", 0, false)]
    public void TestTryCalculate_ReturnsCorrectValues(string input, int expectedOutput, bool expectedValidity)
    {
        Calculator calc = new();
        bool valid = calc.TryCalculate(input, out int result);
        Assert.Equal(expectedValidity, valid);
        Assert.Equal(expectedOutput, result);
    }
}

