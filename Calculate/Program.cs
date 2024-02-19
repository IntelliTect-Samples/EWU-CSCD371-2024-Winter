using System.Net.Http.Headers;

namespace Calculate;

public class Program
{

    //these two propperties will never be null because since it is an init property it ensures that they are set at either object initialization or in a construcator
#nullable disable
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string> ReadLine { get; init; } = Console.ReadLine;
#nullable enable

    public Program() { }

    public static void Main(string[] args )
    {
        Program program = new();
        program.WriteLine("Please enter something: ");
        string input = program.ReadLine();
        program.WriteLine($"You entered: {input}");
    }

}