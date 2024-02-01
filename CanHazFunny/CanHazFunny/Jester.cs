using System;

namespace CanHazFunny;


public class Jester
{
    private readonly IService JokeService;
    private readonly IOutput JokeOutput;

    public Jester(IService jokeService, IOutput jokeOutput)
    {
        this.JokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        this.JokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
    }

    public void TellJoke()
    {
        string joke;
        do
        {
            joke = JokeService.GetJoke();
        } while (joke.Contains("chuck norris", StringComparison.InvariantCultureIgnoreCase));

        JokeOutput.WriteJoke(joke);

    }

}


