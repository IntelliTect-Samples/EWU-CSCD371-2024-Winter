using System.Numerics;

namespace Calculate;
public class Calculator<T> where T : INumber<T>
{
    public IReadOnlyDictionary<char, Func<T, T, T>> MathematicalOperations { get; } = new Dictionary<char, Func<T, T, T>>
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiply,
        ['/'] = Divide
    };

// CA1000 is disabled for this section because the arithmetic methods are required to be static per instructions,
// and this causes warnings when we make them generic for the extra credit
#pragma warning disable CA1000
    public static T Add(T a, T b) => a + b;
    public static T Subtract(T a, T b) => a - b;
    public static T Multiply(T a, T b) => a * b;
    public static T Divide(T a, T b) => !b.Equals(0) ? a / b : throw new ArgumentException("Can't divide by 0", nameof(b));
#pragma warning restore CA1000

    public bool TryCalculate(string calculation, out float result)
    {
        if(calculation == null || calculation == "")
        {
            result = 0;
            return false;
        }
        string[] parts = calculation.Split(' ');
        result = 0;
        if(parts.Length != 3)
        {
           return false;
        }
        float lOperand;
        float rOperand;
        char operatorChar = parts[1][0];

        if(!float.TryParse(parts[0], out lOperand) || !float.TryParse(parts[2], out rOperand))
        {
            return false;
        }
        if(!MathematicalOperations.ContainsKey(operatorChar))
        {
            return false;
        }
        if(MathematicalOperations.TryGetValue(operatorChar, out var operation))
        {
            result = (float)(object)operation((T)(object)lOperand, (T)(object)rOperand);
            return true;
        }
        return false;
    }
}

