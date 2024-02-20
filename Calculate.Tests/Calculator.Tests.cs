using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculate;
using Xunit;
using IntelliTect.TestTools.Console;

namespace Calculate.Tests;

public class CalculatorTests
{
    [Theory]
    [InlineData(3, 2, 5)]
    [InlineData(-1, -1, -2)]
    [InlineData(0, 0, 0)]
    public void Add_CorrectData_ReturnsAdd(int a, int b, int ans)
    {
        int res = Calculator.Add(a, b);
        Assert.Equal(res, ans);
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(-2, -3, 1)]
    [InlineData(0, 0, 0)]
    public void Subtract_CorrectData_ReturnsSubtract(int a, int b, int ans)
    {
        int res = Calculator.Subtract(a, b);
        Assert.Equal(res, ans);
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(-2, -3, 6)]
    [InlineData(5, 0, 0)]
    public void Multiply_CorrectData_ReturnsMultiply(int a, int b, int ans)
    {
        int res = Calculator.Multiply(a, b);
        Assert.Equal(res, ans);
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(-6, -3, 2)]
    [InlineData(3, 3, 1)]
    public void Divide_CorrectData_ReturnsDivide(int a, int b, int ans)
    {
        int res = Calculator.Divide(a, b);
        Assert.Equal(res, ans);
    }

    [Fact]
    public void Divide_Zero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Calculator.Divide(1, 0));
    }

}

public class CalculatorTryCalculateTests
{
    [Theory]
    [InlineData("3 + 2", true, 5)]
    [InlineData("10 - 8", true, 2)]
    [InlineData("4 * 5", true, 20)]
    [InlineData("20 / 4", true, 5)]
    public void TryCalculate_ValidExpressions_ReturnTrue(string expression, bool expSuccess, int expResult)
    {
        Calculator calculator = new();
        bool success = calculator.TryCalculate(expression, out int result);
        Assert.Equal(expSuccess, success);
        Assert.Equal(expResult, result);

    }

    [Theory]
    [InlineData("10-8", false)]
    [InlineData("4 # 5", false)]
    [InlineData(" ", false)]
    public void TryCalculate_InvalidExpressions_ReturnFalse(string expression, bool expSuccess)
    {
        Calculator calculator = new();
        bool success = calculator.TryCalculate(expression, out _);
        Assert.Equal(expSuccess, success);

    }

    [Fact]
    public void TryCalculate_Null_ReturnsFalse()
    {
        Calculator calulator = new();
        Assert.Throws<ArgumentNullException> (() => calulator.TryCalculate(null!, out int _));
    }
}
