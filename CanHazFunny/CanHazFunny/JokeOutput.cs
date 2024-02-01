using System;
using System.IO;
using System.Net.Http;

namespace CanHazFunny;

public class JokeOutput : IOutput
{
    public void WriteJoke(string joke)
    {
        ArgumentNullException.ThrowIfNull(joke);
        Console.WriteLine(joke);
    }

   

}

