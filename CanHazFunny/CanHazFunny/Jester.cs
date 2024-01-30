using System;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IJokeService _jokeService;

        // Constructor with dependency injection (DI)
        public Jester(IOutputWriter outputWriter, IJokeService jokeService)
        {
            // Null checks for dependencies
            _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
            _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        }

        public void TellJoke()
        {
            // Retrieve a joke from the service
            string joke = _jokeService.GetJoke();

            // Check if the joke contains "Chuck Norris"
            while (joke.Contains("Chuck Norris"))
            {
                joke = _jokeService.GetJoke();
            }

            // Write the joke to the output
            _outputWriter.Write(joke);
        }
    }
}