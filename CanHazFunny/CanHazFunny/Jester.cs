using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        IJokeOutput JokeOutput { get; set; }
        IJokeGetter JokeGetter { get; set; }
        public string Joke { get; set; } = "";

        public Jester(IJokeOutput jokeOutput, IJokeGetter jokeGetter) {
            JokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
            JokeGetter = jokeGetter ?? throw new ArgumentNullException(nameof (jokeGetter));
        }
        public string TellJoke()
        {
            Joke = JokeGetter.GetJoke();
            do {
                Joke = JokeGetter.GetJoke();
            } while(Joke.Contains("chuck norris", StringComparison.OrdinalIgnoreCase));
            JokeOutput.TellJoke(Joke);
            return Joke;
        }
    }
}
