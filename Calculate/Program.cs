

namespace Calculate;

public class Program(Action<string> WriteLine, Func<string?> ReadLine)
{
    public Action<string> WriteLine { get; init; } = WriteLine;
    public Func<string?> ReadLine { get; init; } = ReadLine;


    public Program() : this(Console.WriteLine, Console.ReadLine)
    {
    }

    public static void Main(string[] args)
    {
    }
}
