using System;
namespace CanHazFunny
{
    public class JokeOutput : IJokeOutput
    {
        public void PrintingJoke(string jokePrint)
        {
            Console.WriteLine(jokePrint);
        }
    }
}

