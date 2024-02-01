using System;

namespace CanHazFunny;

public class Jester
{


    private readonly IJokeService _jokeService;
    private readonly IJokeOutput _jokeOutput;

    public Jester(IJokeService jokeService, IJokeOutput jokeOutput)
    {
        _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        _jokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
    }
    public void TellJoke()
    {
        string joke = "";

        do
        {
            joke = _jokeService.GetJoke();

        } while (joke.Contains("chuck norris", StringComparison.OrdinalIgnoreCase));

        _jokeOutput.PrintingJoke(joke);
    }
}


