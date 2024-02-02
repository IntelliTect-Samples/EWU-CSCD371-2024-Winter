using System;

namespace CanHazFunny;
    public class Jester(IJokeService jokeService, IOutputToScreen jokeWriter)
{
    public IJokeService JokeService { get; private set; } = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    public IOutputToScreen JokeWriter { get; private set; } = jokeWriter ?? throw new ArgumentNullException(nameof(jokeWriter));

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
