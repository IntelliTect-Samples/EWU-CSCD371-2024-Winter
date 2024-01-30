using System;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IOutputWriter _outputWriter;
        private readonly IJokeService _jokeService;
        
        //Constructor with DI
        public Jester (IOutputWriter outputWriter, IJokeService jokeService)
        {
            //Null for dependencies
            _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
            _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        }

        public void TellJoke()
        {
            string joke = _jokeService.GetJoke();

            while (joke.Contains("Chuck Norris"))
            {
                joke = _jokeService.GetJoke();
            }

            _outputWriter.Write(joke);
        }
    
    }
}
