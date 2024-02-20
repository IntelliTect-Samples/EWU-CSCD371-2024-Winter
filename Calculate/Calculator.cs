
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

    public static bool TryCalculate(string expresion, out int result)
    {
        string[] ops = expresion.Split(' ');
        int num1 = 0;
        int num2 = 0;
        result = 0;
        if (int.TryParse(ops[0], out num1) && int.TryParse(ops[2], out num2) )
        {
            if (ops[1] == "+")
            {
                result = Add(num1,num2);
                return true;
            }
        }

        return false;
    }
}

