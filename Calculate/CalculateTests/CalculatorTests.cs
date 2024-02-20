using Calculate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}

