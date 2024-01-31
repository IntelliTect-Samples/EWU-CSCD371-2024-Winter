using System;

namespace CanHazFunny;

public class OutputService : IOutputService
{
    public void DisplayJoke(string joke)
    {
        ArgumentNullException.ThrowIfNull(joke);
        Console.WriteLine(joke);
    }
}