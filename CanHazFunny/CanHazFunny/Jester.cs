using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CanHazFunny
{
    public class Jester
    {
        public IJokeService jokeService { get; private set; }
        public IOutputToScreen jokeWriter { get; private set; }

        public Jester(IJokeService jokeService, IOutputToScreen jokeWriter)
        {
            this.jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            this.jokeWriter = jokeWriter ?? throw new ArgumentNullException(nameof(jokeWriter));

        }
        public void TellJoke()
        {
            string joke;
            joke = jokeService.GetJoke();
            while (joke.ToLower().Contains("chuck norris"))
            {
                joke = jokeService.GetJoke();
            }
            jokeWriter.WriteJokeToScreen(joke);
        }
    }   
}
