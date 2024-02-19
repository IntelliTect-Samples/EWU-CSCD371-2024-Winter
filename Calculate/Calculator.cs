
using System.Security.Cryptography;

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

    public bool TryCalculate(string calculation, out int? result)
    {
        string [] calcParts = calculation.Split(" ");

        if(calcParts.Length != 3)
        {
            result = null;
            return false;
        }
        else
        {
            if(calcParts[0].All(char.IsDigit) && calcParts[2].All(char.IsDigit))
            {
                if (MathematicalOperations.ContainsKey(char.Parse(calcParts[1])))
                {
                    try
                    {
                        char[] op = calcParts[1].ToCharArray();
                        Func<int,int,int> operation = MathematicalOperations[op[0]];
                        result = operation(Int32.Parse(calcParts[0]), Int32.Parse(calcParts[2]));
                        return true;
                    }
                    catch (FormatException)
                    {
                        throw new FormatException($"Unable to parse {calcParts[0]} or {calcParts[3]}");
                    }
                }
            }
        }
        result = null;
        return false;
    }
}
