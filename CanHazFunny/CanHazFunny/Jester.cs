using System;

namespace CanHazFunny;

public class Jester(IJokeOutput jokeOutput, IJokeService jokeService)
{
    private readonly IJokeOutput _outputToScreen = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput)); 
    private readonly IJokeService _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    public void TellJoke()
    {
        string joke = _jokeService.GetJoke();
        while (joke.Contains("Chuck Norris"))
        {
            joke = _jokeService.GetJoke();
        } 

        _outputToScreen.PrintJoke(joke);
    }
}
