using System;

namespace CanHazFunny;

public class Jester
{
    public readonly IJokeService jokeService;
    public readonly IJokeOutput jokeOutput;

    public Jester(IJokeService jokeService, IJokeOutput jokeOutput)
    {
        this.jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        this.jokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
    }
    public string GetJoke()
    {

    }
}