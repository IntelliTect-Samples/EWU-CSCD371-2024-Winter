using System;

namespace CanHazFunny;

public class OutputService : IOutputService
{
    public void DisplayJoke(string joke)
    {
        Console.WriteLine(joke);
    }
}