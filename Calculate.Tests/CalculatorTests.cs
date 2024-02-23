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
        Assert.Equal<int>(expected, result);
    }


    [Theory]
    [InlineData(0,1,1)]
    [InlineData(0, 100, 100)]
    [InlineData(-1, 1, 2)]
    [InlineData(-101,-100, 1)]
    [InlineData(0, -1, -1)]
    public void Subtract_ReturnCorrectResult_True(int expected, int value1, int value2)
    {
        int result = Calculator.Subtract(value1, value2);
        Assert.Equal<int>(expected, result);
    }


    [Theory]
    [InlineData(12,3,4)]
    [InlineData(12,2,6)]
    public void Multilple_Success(int expected, int value1, int value2)
    {
        Assert.Equal<int>(expected, Calculator.Multiply(value1, value2));
    }

    [Theory]
    [InlineData(0.5,1,2)]
    [InlineData(2,4,2)]
    [InlineData(2,8,4)]
    public void Divide_Success(int expected, int value1, int value2)
    {
        Assert.Equal<int>(expected, Calculator.Divide( value1, value2));
    }

    [Theory]
    [InlineData(4, '+', 2, 2)]
    [InlineData(10, '-', 21, 11)]
    [InlineData(-99, '+', -100, 1)]
    [InlineData(50, '*', 5, 10)]
    [InlineData(25, '/', 75, 3)]
    public void MathematicalOperations(int expected, char mathSymbol, int value1, int value2)
    {
        Calculator calculator = new();
        Func<int,int,int> operation = calculator.MathematicalOperations[mathSymbol];
        int result = operation(value1, value2);
        Assert.Equal<int>(expected, result);
    }

    [Theory]
    [InlineData(7, "3 + 4")]
    [InlineData(40, "42 - 2")]
    [InlineData(0, "9999999 * 0")]
    [InlineData(1, "100 / 100")]
    public void TryCalculate(int expected, string expression)
    {
        Calculator calculator = new();
        bool result = calculator.TryCalculate(expression, out int? answer);
        Assert.True(result);
        Assert.Equal<int?>(expected, answer);
    } 
}