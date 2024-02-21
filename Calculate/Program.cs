using System.Globalization;

namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public Program()
    {
    }

    public static void Main(string[] args)
    {

        int res;
        string? expression;
        Program program = new();
        Calculator calculator = new Calculator();
        do
        {
            program.WriteLine("Please Enter Your Expression: ");
            expression = program.ReadLine();

        } while (!calculator.TryCalculate(expression!, out res));

        program.WriteLine(res.ToString(CultureInfo.InvariantCulture));
 
    }
}
