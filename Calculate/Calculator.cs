using System.Collections.Generic;
using System;

namespace Calculate;

public class Calculator
{
    public static IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; }
    = new Dictionary<char, Func<int, int, int>>()
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiple,
        ['/'] = Divide,
    };
    public static int Add(int a, int b)
    {
        int answer = a + b;
        return answer;
    }

    public static int Subtract(int a, int b)
    {
        int answer = a - b;
        return answer;
    }

    public static int Multiple(int a, int b)
    {
        int answer = a * b;
        return answer;
    }

    public static int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Divide by 0 Error");
        }

        int answer = a / b;
        return answer;
    }

    public static bool TryCalculate(string expression, out int? result)
    {
        string[] equationParts = expression.Split(" ");

        if (equationParts.Length != 3)
        {
            result = null;
            return false;
        }
        else
        {
            if (int.TryParse(equationParts[0], out int variable1) && int.TryParse(equationParts[2], out int variable2))
            {
                try
                {
                    char[] opperand = equationParts[1].ToCharArray();
                    if (!MathematicalOperations.ContainsKey(opperand[0]))
                    {
                        result = null;
                        return false;
                    }

                    Func<int, int, int> opperation = MathematicalOperations[opperand[0]];
                    //result = opperation(double.Parse(equationParts[0]), double.Parse(equationParts[2]));
                    result = opperation(variable1, variable2);
                    return true;
                }
                catch (FormatException)
                {
                    throw new FormatException($"Unable to Parse {equationParts[0]} or {equationParts[2]}");
                }

            }
        }
        result = null;
        return false;
    }
}
