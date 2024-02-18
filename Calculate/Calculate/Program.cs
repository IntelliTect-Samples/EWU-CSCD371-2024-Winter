using System;

namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; }
    public Func<string> ReadLine { get; init; }

    public Program()
    {
        WriteLine = Console.WriteLine;
        ReadLine = Console.ReadLine;
    }

    public Program(Action<string> writeLine, Func<string> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    public static void Main(string[] args)
    {
        Program program = new();
        Calculator calculator = new();

        program.WriteLine("Enter an expression: ");
        string expression = program.ReadLine();
        if (calculator.TryCalculate(expression, out var result))
        {
            program.WriteLine($"Result: {result}");
        }
        else
        {
            program.WriteLine("Invalid expression.");
        }

    }
}