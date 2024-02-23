using System.Data;
using static Calculate.Program;

namespace Calculate;

public class Program
{
    public delegate void DelegateWriteLine(string text);
    public delegate string? DelegateReadLine();


    public DelegateWriteLine WriteLine { get; init; }
    public DelegateReadLine ReadLine { get; init; }


    public Program()
    {
        WriteLine ??= Console.WriteLine;
        ReadLine ??= Console.ReadLine;
    }
    public static void Main()
    {

        string? expression = "";
        Program program = new();
        Calculator calc = new();
        do
        {
            program.WriteLine("Please Enter Your Expression: ");
            expression = program.ReadLine();
            calc.TryCalculate(expression!, out int result);
            program.WriteLine(result.ToString("N", System.Globalization.CultureInfo.CurrentCulture));

        } while (calc.TryCalculate(expression!, out _));

    }
}


