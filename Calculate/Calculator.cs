using System.Globalization;
using System.Numerics;

namespace Calculate;

public class Calculator<T> where T : INumber<T>
{
    public IReadOnlyDictionary<char, Func<T, T, T>> MathematicalOperations { get; }

    public Calculator()
    {
        MathematicalOperations = new Dictionary<char, Func<T, T, T>>()
        {
            {'+',Add},
            {'-',Subtract},
            {'*',Multiply},
            {'/',Divide }
        };
    }

    public T Add(T value, T value2)
    {
        return value + value2;
    }

    public T Subtract(T value, T value2)
    {
        return value - value2;
    }

    public T Multiply(T value, T value2)
    {
        return value * value2;
    }

    public T Divide(T value, T value2)
    {
        if (value2 == T.Zero)
            throw new DivideByZeroException("Cannot divide by zero");

        return value / value2;
    }

    public bool TryCalculate(string? expresion, out T result)
    {
        result = T.Zero;
        if (expresion == null) { return false; }
        string[] ops = expresion.Split(' ');

        if (ops.Length != 3 || ops[1].Length != 1) { return false; }

        if (T.TryParse(ops[0], CultureInfo.InvariantCulture ,out T? num1) && T.TryParse(ops[2], CultureInfo.InvariantCulture, out T? num2) && MathematicalOperations.TryGetValue(ops[1][0], out Func<T, T, T>? operation))
        {
                result = operation(num1, num2);
                return true;
        }
        return false;
    }
}

