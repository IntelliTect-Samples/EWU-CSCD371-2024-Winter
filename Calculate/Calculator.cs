using System.Globalization;
using System.Numerics;

namespace Calculate;

public class Calculator<T> where T : INumber<T>
{

    public IReadOnlyDictionary<char, Func<T, T, T>> MathematicalOperations { get; } = new Dictionary<char, Func<T, T, T>>()
        { 
        {'+',(num1, num2) => num1 + num2},
        {'-',(num1, num2) => num1 - num2},
        {'*',(num1, num2) => num1 * num2},
        {'/', (num1, num2) => {
            if(num2 == T.Zero) 
                throw new DivideByZeroException(nameof(num2));
                return num1 / num2;
            } }
        };


    public bool TryCalculate(string expresion, out T result)
    {
        string[] ops = expresion.Split(' ');
        result = T.Zero;

        if (ops.Length != 3) { return false; }
        if (ops[1].Length != 1) { return false; }

        if (T.TryParse(ops[0], CultureInfo.InvariantCulture ,out T? num1) && T.TryParse(ops[2], CultureInfo.InvariantCulture, out T? num2))
        {

            if (!MathematicalOperations.ContainsKey(ops[1][0])) { return false; }

            result = MathematicalOperations[ops[1][0]](num1, num2);
            return true;
        }
        return false;
    }
}

