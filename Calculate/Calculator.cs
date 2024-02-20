using System.Collections.Generic;

namespace Calculate;

public class Calculator
{
    public static IReadOnlyDictionary<char, Func<double, double, double>> MathematicalOperations { get; }
    = new Dictionary<char, Func<double, double, double>>()
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiple,
        ['/'] = Divide,
    };
    public static double Add(double a, double b)
    {
        double answer = a + b;
        return answer;
    }

    public static double Subtract(double a, double b)
    {
        double answer = a - b;
        return answer;
    }

    public static double Multiple(double a, double b)
    {
        double answer = a * b;
        return answer;
    }

    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Divide by 0 Error");
        }

        double answer = a / b;
        return answer;
    }

    public static void TryCalculate()
    {

    }
}
