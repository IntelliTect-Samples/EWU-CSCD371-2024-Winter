using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate;

internal class Calculator
{
    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
    public static int Divide(int a, int b) => a / b;

    public readonly IReadOnlyDictionary<char, Func<int, int, int>> MathOperations =
        new Dictionary<char, Func<int, int, int>>
        {
            {'+', Add },
            {'-', Subtract },
            {'*', Multiply },
            {'/', Divide }
        };

    public bool TryCalculate(string expression, out int result)
    {
        result = 0;
        string[] parts = expression.Split(' ');
        if (parts.Length != 3) return false;

        if (!int.TryParse(parts[0], out int lhs) || !int.TryParse(parts[2], out int rhs)) return false;

        char op = parts[1][0];
        if(!MathOperations.TryGetValue(op, out var func)) return false;

        result = func(lhs, rhs);
        return true;
    }

}
