using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester(IJokeService jokeService, IJokeToScreen jokeToScreen)
    {
        private IJokeService _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        private IJokeToScreen _jokeToScreen = jokeToScreen ?? throw new ArgumentNullException(nameof(jokeToScreen));
        public void TellJoke()
        {
            string joke;
            do
            {
                joke = _jokeService.GetJoke();
            } while (joke.Contains("Chuck Norris"));

            _jokeToScreen.PrintJoke(joke);
        }
    }
}
