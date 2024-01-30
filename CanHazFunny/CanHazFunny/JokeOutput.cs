using System;

namespace CanHazFunny;

public class JokeOutput : IJokeOutput
{
    public void PrintJoke(string joke)
    {
        ArgumentNullException.ThrowIfNull(joke);
        Console.WriteLine(joke);
    }
}