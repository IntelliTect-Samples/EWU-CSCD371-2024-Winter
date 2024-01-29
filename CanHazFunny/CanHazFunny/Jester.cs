using System;

namespace CanHazFunny;

public class Jester
{
    private readonly IJokeService jokeService;
    private readonly IJokeOutput jokeOutput;

    public Jester(IJokeService jokeService, IJokeOutput jokeOutput)
    {
        this.jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        this.jokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
    }
    public void TellJoke()
    {
        string joke = "";

        do{
            joke = jokeService.GetJoke();

        }while (joke.Contains("chuck norris", StringComparison.OrdinalIgnoreCase));

        jokeOutput.PrintingJoke(joke);
    }
}