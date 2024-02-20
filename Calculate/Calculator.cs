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

    public bool TryCalculate(string expression, out double? result)
    {
        string[] equationParts = expression.Split(" ");

        if (equationParts.Length != 3)
        {
            result = null;
            return false;
        } 
        else
        {
            if (double.TryParse(equationParts[0], out double variable1) && double.TryParse(equationParts[2], out double variable2))
            {
                try
                {
                    char[] opperand = equationParts[1].ToCharArray();
                    Func<double, double, double> opperation = MathematicalOperations[opperand[0]];
                    result = opperation(double.Parse(equationParts[0]), double.Parse(equationParts[2]));
                    return true;
                }
                catch (FormatException)
                {
                    throw new FormatException($"Unable to Parse {equationParts[0]} or {equationParts[3]}");
                }

            }
        }
        result = null;
        return false;
    }
}
