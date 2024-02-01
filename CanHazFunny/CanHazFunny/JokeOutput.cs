using System;
namespace CanHazFunny;

    public class JokeOutput : IJokeOutput
    {
        public void PrintingJoke(string jokePrint)
        {
            ArgumentNullException.ThrowIfNull(jokePrint);
            Console.WriteLine(jokePrint);
        }
    }

