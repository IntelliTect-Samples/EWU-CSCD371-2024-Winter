
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

    public bool TryCalculate(string calculation)
    {
        string [] calcParts = calculation.Split(" ");

        if(calcParts.Length < 3 || calcParts.Length > 3){
            return false;
        }
        else{
            if(calcParts[0].All(char.IsDigit) && calcParts[3].All(char.IsDigit))
            {
                if(calcParts[2] == "+" || calcParts[2] == "-" || calcParts[2] == "*" || calcParts[2] == "/")
                {
                    char[] op = calcParts[2].ToCharArray();
                    Func<int,int,int> operation = MathematicalOperations[op[0]];
                    return true;
                }
            }
        }
        return false;
    }
}
