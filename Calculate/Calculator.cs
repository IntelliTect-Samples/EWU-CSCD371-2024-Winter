using System.Numerics;

namespace Calculate;
public class Calculator<T> where T : INumber<T>, IParsable<T>
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

    public bool TryCalculate(string calculation, out T result)
    {
        if(calculation == null || calculation == "")
        {
            result = T.Zero;
            return false;
        }
        string[] parts = calculation.Split(' ');
        result = T.Zero;
        if(parts.Length != 3)
        {
           return false;
        }
        T lOperand = T.Zero;
        T rOperand = T.Zero;
        char operatorChar = parts[1][0];

        if(!T.TryParse(parts[0], System.Globalization.NumberFormatInfo.CurrentInfo, out lOperand!)
            || !T.TryParse(parts[2], System.Globalization.NumberFormatInfo.CurrentInfo, out rOperand!))
        {
            return false;
        }
        if(!MathematicalOperations.ContainsKey(operatorChar))
        {
            return false;
        }
        if(MathematicalOperations.TryGetValue(operatorChar, out var operation))
        {
            result = operation(lOperand, rOperand);
            return true;
        }
        return false;
    }
}

