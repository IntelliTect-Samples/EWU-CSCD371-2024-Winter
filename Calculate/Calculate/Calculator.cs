namespace Calculate;
public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, int>>
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiply,
        ['/'] = Divide
    };

    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
    public static int Divide(int a, int b) => b != 0 ? a / b : throw new ArgumentException("Can't divide by 0", nameof(b));

    public bool TryCalculate(string calculation, out int result)
    {
        ArgumentException.ThrowIfNullOrEmpty(calculation, nameof(calculation));
        string[] parts = calculation.Split(' ');
        result = 0;
        if(parts.Length != 3)
        {
           return false;
        }
        int lOperand;
        int rOperand;
        char operatorChar = parts[1][0];

        if(!int.TryParse(parts[0], out lOperand) || !int.TryParse(parts[2], out rOperand))
        {
            return false;
        }
        if(!MathematicalOperations.ContainsKey(operatorChar))
        {
            return false;
        }
        if(MathematicalOperations.TryGetValue(operatorChar, out Func<int, int, int>? operation))
        {
            result = operation(lOperand, rOperand);
            return true;
        }
        return false;
    }
}

