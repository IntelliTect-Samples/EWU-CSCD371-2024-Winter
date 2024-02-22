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
    public void TestAddInt(int a, int b, int expected)
    {
        int result = Calculator<int>.Add(a, b);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(3.1, 3.2, 6.3)]
    [InlineData(0.1, -0.2, -0.1)]
    public void TestAddFloat(float a, float b, float expected)
    {
        float result = Calculator<float>.Add(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(3, 4, -1)]
    [InlineData(42, 2, 40)]
    [InlineData(6, 7, -1)]
    [InlineData(20, 5, 15)]
    public void TestSubtractInt(int a, int b, int expected)
    {
        int result = Calculator<int>.Subtract(a, b);

        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(3, 4, 12)]
    [InlineData(42, 2, 84)]
    [InlineData(6, 7, 42)]
    [InlineData(20, 5, 100)]
    public void TestMultiplyInt(int a, int b, int expected)
    {
        int result = Calculator<int>.Multiply(a, b);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(6, 3, 2)]
    [InlineData(40, 2, 20)]
    [InlineData(49, 7, 7)]
    [InlineData(20, 5, 4)]
    public void TestDivideInt(int a, int b, int expected)
    {
        int result = Calculator<int>.Divide(a, b);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestDivide_ZeroDenominator_Throws()
    {
        Assert.Throws<ArgumentException>(() => Calculator<int>.Divide(3, 0));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void TestTryCalculate_NullOrEmpty_ReturnsFalse(string input)
    {
        Calculator<float> calc = new();
        Assert.False(calc.TryCalculate(input, out float blah));
    }

    [Theory]
    [InlineData("2 + 3", 5, true)]
    [InlineData("-4 - 3", -7, true)]
    [InlineData("2", 0, false)]
    [InlineData("2+3", 0, false)]
    [InlineData("1.53 + -3", -1.47, true)]
    public void TestTryCalculate_ReturnsCorrectValues(string input, float expectedOutput, bool expectedValidity)
    {
        Calculator<float> calc = new();
        bool valid = calc.TryCalculate(input, out float result);
        Assert.Equal(expectedValidity, valid);
        Assert.Equal(expectedOutput, result);
    }
}

