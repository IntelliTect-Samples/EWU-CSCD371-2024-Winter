namespace Calculate;

public class Program
{

    public Action<string> WriteLine { get; init; } = System.Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = System.Console.ReadLine;


    public Program() { }

    public static void Main(string[] args)
        {
            // Your application logic goes here
        }

}


