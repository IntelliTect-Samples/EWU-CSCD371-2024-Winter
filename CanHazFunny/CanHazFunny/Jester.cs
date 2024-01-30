using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester : IJokeOutput
    {
        IJokeOutput JokeOutput { get; set; }
        IJokeGetter JokeGetter { get; set; }
        public string Joke { get; set; } = "";

        public Jester(IJokeOutput jokeOutput, IJokeGetter jokeGetter) {
            if(jokeOutput == null)
            {
                throw new ArgumentNullException(nameof(jokeOutput));
            }
            if(jokeGetter == null)
            {
                throw new ArgumentNullException(nameof (jokeGetter));
            }
            JokeOutput = jokeOutput;
            JokeGetter = jokeGetter;
        }
        public void TellJoke()
        {
            Joke = JokeGetter.GetJoke();
            if(Joke.Contains("Chuck Norris"))
            {
                Joke = JokeGetter.GetJoke();
            }
            JokeOutput.Joke = Joke;
            JokeOutput.TellJoke();
        }
    }
}
