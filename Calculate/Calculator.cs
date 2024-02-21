
namespace Calculate;

public class Calculator
{

    public IReadOnlyDictionary<char, Func<int,int,int>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, int>>()
        { 
        {'+',Add},
        {'-',Subtract},
        {'*',Multiply },
        {'/', Divide}
        };
    
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

    public bool TryCalculate(string expresion, out int result)
    {
        string[] ops = expresion.Split(' ');
        result = 0;

        if (ops.Length != 3) { return false; }
        if (ops[1].Length != 1) { return false; }

        if (int.TryParse(ops[0], out int num1) && int.TryParse(ops[2], out int num2))
        {

            if (!MathematicalOperations.ContainsKey(ops[1][0])) { return false; }

            result = MathematicalOperations[ops[1][0]](num1, num2);
            return true;
        }
        return false;
    }
}

