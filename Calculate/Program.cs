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
        do
        {
            program.WriteLine("Please Enter Your Expression: ");
            expression = program.ReadLine();

        } while (!Calculator.TryCalculate(expression!, out res));

        program.WriteLine(res.ToString(CultureInfo.InvariantCulture));
 
    }
}
