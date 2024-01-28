using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CanHazFunny
{
    public class Jester
    {
        public IJokeService JokeService { get; private set; }
        public IOutputToScreen JokeWriter { get; private set; }

        public Jester(IJokeService jokeService, IOutputToScreen jokeWriter)
        {
            this.JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
            this.JokeWriter = jokeWriter ?? throw new ArgumentNullException(nameof(jokeWriter));

        }
        public void TellJoke()
        {
            string joke;

            do
            {
                joke = JokeService.GetJoke();
            } while (joke.Contains("chuck norris", StringComparison.CurrentCultureIgnoreCase));


            JokeWriter.WriteJokeToScreen(joke);

        }
    }   
}
