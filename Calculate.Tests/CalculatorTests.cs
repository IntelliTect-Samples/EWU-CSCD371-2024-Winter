using System;
using Xunit;

namespace Calculate.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(4, 2, 2)]
    [InlineData(9, 6, 3)]
    [InlineData(-3, -5, 2)]
    [InlineData(5.5, 2.2, 3.3)]
    public void Add_ReturnSumOfTwoValues_Equal(double expected, double val1, double val2)
    {
        double sum = Calculator.Add(val1, val2);
        Assert.Equal(expected, sum);
    }

    [Theory]
    [InlineData(0, 2, 2)]
    [InlineData(3, 6, 3)]
    [InlineData(-7, -5, 2)]
    [InlineData(7.8, 8, 0.2)]
    public void Subtract_ReturnDifferenceOfTwoValues_Equal(double expected, double val1, double val2)
    {
        double difference = Calculator.Subtract(val1, val2);
        Assert.Equal(expected, difference);
    }

    [Theory]
    [InlineData(4, 2, 2)]
    [InlineData(18, 6, 3)]
    [InlineData(6.6, 3.3, 2)]
    public void Multiply_ReturnProductOfTwoValues_Equal(double expected, double val1, double val2)
    {
        double product = Calculator.Multiple(val1, val2);
        Assert.Equal(expected, product);
    }

    [Theory]
    [InlineData(1, 2, 2)]
    [InlineData(2, 6, 3)]
    [InlineData(2.5, 5, 2)]
    public void Divide_ReturnQuotientOfTwoValues_Equal(double expected, double val1, double val2)
    {
        double quotient = Calculator.Divide(val1, val2);
        Assert.Equal(expected, quotient);
    }

    [Fact]
    public void Divide_DivideByZero_ThrowException()
    {
        Assert.Throws<ArgumentException>(() => Calculator.Divide(69, 0));
    }

    [Theory]
    [InlineData('+', 4, 2, 2)]
    [InlineData('-', 0, 2, 2)]
    [InlineData('*', 4, 2, 2)]
    [InlineData('/', 1, 2, 2)]
    [InlineData('+', 79.3, 56.1, 23.2)]
    [InlineData('-', -5.5, 36.5, 42)]
    [InlineData('*', 19.2, 9.6, 2)]
    [InlineData('/', 1.5, -18, -12)]
    public void MathematicalOperations_VariousOperations_Equal(char operatorSymbol, double expected, double val1, double val2)
    {
        var operation = Calculator.MathematicalOperations[operatorSymbol];
        double result = operation(val1, val2);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TryCalculate_TooManyParams_FalseAndNullAnswer()
    {
        string input = "7 + 8 6";
        Assert.False(Calculator.TryCalculate(input, out double? ans));
        Assert.Null(ans);
    }

    [Fact]
    public void TryCalculate_BadOperatorSymbol_FalseAndNullAnswer()
    {
        string input = "3 , 4";
        Assert.False(Calculator.TryCalculate(input, out double? ans));
        Assert.Null(ans);
    }
}
