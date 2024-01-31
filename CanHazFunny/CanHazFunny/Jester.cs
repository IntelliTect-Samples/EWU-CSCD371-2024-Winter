using System;

namespace CanHazFunny;

public class Jester(IJokeService jokeService, IOutputService outputService)
{
    public IJokeService JokeService { get; } = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    public IOutputService OutputService { get; } = outputService ?? throw new ArgumentNullException(nameof(outputService));
    
    public virtual void TellJoke()
    {
        string joke;
        do
        {
            joke = JokeService.GetJoke();
        } while (joke.Contains("Chuck Norris"));

        OutputService.DisplayJoke(joke);
    }


}

