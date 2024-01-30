using System;

namespace CanHazFunny;


public class JokeOutput : IJokeOutput
{
    public void OutputJoke(string joke)
    {
        Console.WriteLine(joke);
    }
}