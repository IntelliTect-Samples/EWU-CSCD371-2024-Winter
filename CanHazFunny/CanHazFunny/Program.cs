using System;

namespace CanHazFunny;

class Program
{
    static void Main(string[] args)
    {
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
        IJokeService jokeService = new JokeService();
        IOutputService consoleOutput = new ConsoleOutputService();
        Jester jester = new Jester(jokeService, consoleOutput);

        try
        {
            jester.TellJoke();
        } catch(Exception ex)
        {
            Console.WriteLine($"An Error occured: {ex.Message}");
        }
    }
}
