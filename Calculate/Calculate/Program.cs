namespace Calculate;
public class Program
{
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;
    public const string InvalidInputMessage = "Invalid input. Operator and integer operands must be separated by a single space";

    public Program() { }

    public void CalculateInput()
    {
        string? input = ReadLine();
        if (input == null)
        {
            WriteLine("No input given");
            return;
        }
        Calculator calculator = new();
        if (calculator.TryCalculate(input, out int result))
        {
            WriteLine($"Result of {input} = {result}");
        }
        else
        {
            WriteLine(InvalidInputMessage);
        }
    }

    public static void Main()
    {
        Program program = new();
        program.WriteLine("Enter a simple arithmetic expression (e.g., 3 + 2):");
        program.CalculateInput();
    }
 }

