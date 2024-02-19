namespace Calculate;

public class Program
{

    public Action<string> WriteLine { get; init; }
    public Func<string> ReadLine { get; init; }


    public Program(Action<string> writeLine, Func<string> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

}


