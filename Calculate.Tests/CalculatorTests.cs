using Xunit;
using Xunit.Sdk;

namespace Calculate.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(2,1,1)]
    [InlineData(-2, -5, 3)]
    [InlineData(100, 99, 1)]
    [InlineData(25, 14, 11)]
    public void Add_ReturnCorrectResult_True(int expected, int value1, int value2)
    {
        int result = Calculator.Add(value1, value2);
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData(0,1,1)]
    public void Subtract_ReturnCorrectResult_True(int expected, int value1, int value2)
    {
        int result = Calculator.Subtract(value1, value2);
        Assert.Equal(expected, result);
    }


    [Fact]
    public void Multilple_Success()
    {
        Assert.Equal<int>(12, Calculator.Multiple(3,4));
    }

    [Fact]
    public void Divide_Success()
    {
        Assert.Equal<double>(2.0, Calculator.Divide(8,4));
    }
}