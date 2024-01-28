using System;

namespace CanHazFunny;

public class OutputService : IOutJoke
{
    public void DisplayJoke(string joke)
    {
        ArgumentNullException.ThrowIfNull(joke);
        Console.WriteLine(joke);
    }
}