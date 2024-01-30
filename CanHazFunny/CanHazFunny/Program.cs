using System;

namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of concrete implementations
            IOutputWriter outputWriter = new ConsoleOutputWriter();
            IJokeService jokeService = new JokeService();

            // Create an instance of Jester with concrete dependencies
            Jester jester = new Jester(outputWriter, jokeService);

            // Tell a joke
            jester.TellJoke();
        }
    }
}