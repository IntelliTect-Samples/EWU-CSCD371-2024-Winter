using System;

namespace Calculate;
public class Program
{
#nullable disable
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string> ReadLine { get; init; } = Console.ReadLine;
#nullable enable
    public Program(){ }

    public static void Main(string[] args)
    {
        Program program = new();
        //Calculator calculator = new();
        string input;
        double? answer;

        do
        {
            program.WriteLine("Enter Simple Equation: ");
            input = program.ReadLine();
        }
        //while (!calculator.TryCalculate(input, out answer));
        while (!Calculator.TryCalculate(input, out answer));

        program.WriteLine($"Answer: {answer}");
    }
}
