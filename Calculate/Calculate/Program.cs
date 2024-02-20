using System;

namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine; //ReadLine may return null, this will be caught in our main.

    public Program()
    { }

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