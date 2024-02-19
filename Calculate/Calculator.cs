
namespace Calculate;

public class Calculator
{

    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } = 
        new Dictionary<char, Func<int, int, int>>()
        {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiple,
            ['/'] = Divide

        };

    public static int Add(int value1, int value2)
    {
        return value1 + value2;
    }

    public static int Subtract(int value1, int value2)
    {
        return value1 - value2;
    }

    public static int Multiple(int multiplicand, int multiplier)
    {
        return multiplicand * multiplier;
    }

    public static int Divide(int dividend, int divisor)
    {
        return dividend / divisor;
    }
}
