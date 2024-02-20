using System;

namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; }
    public Func<string?> ReadLine { get; init; } //ReadLine may return null, this is so we can catch the null error later on

    public Program()
    {
        WriteLine = Console.WriteLine;
        ReadLine = Console.ReadLine;
    }

    public Program(Action<string> writeLine, Func<string?> readLine)
    {
        WriteLine = writeLine ?? throw new ArgumentNullException(nameof(writeLine));
        ReadLine = readLine ?? throw new ArgumentNullException(nameof(readLine));
    }

    public static void Main(string[] args)
    {
        Program program = new();
        Calculator calculator = new();

        program.WriteLine("Enter an expression: ");
        string? expression = program.ReadLine();
        if (expression != null && calculator.TryCalculate(expression, out var result))
        {
            program.WriteLine($"Result: {result}");
        }
        else
        {
            program.WriteLine("Invalid expression.");
        }

    }
}