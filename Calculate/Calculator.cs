
namespace Calculate;

public class Calculator
{

    public IReadOnlyDictionary<char, int> MathematicalOperations { get; } = new Dictionary<char, int>()
        { {'+',0 },
        {'-',1 },
        {'-',2 },
        {'-',3 }};
    
    public static int Add(int num1, int num2)
    {
        return num1 + num2;
    }
    public static int Subtract(int num1, int num2)
    {
        return num1 - num2;

    }
    public static int Multiply(int num1, int num2)
    {
        return num1 * num2;
    }
    public static int Divide(int num1, int num2)
    {
        return num1 / num2;
    }

    public static bool TryCalculate(string v)
    {
        throw new NotImplementedException();
    }
}

