using System;

namespace CanHazFunny;

public class Jester
{
    private IJokeService? _JokeService;

    public IJokeService JokeService
    {
        get { return _JokeService!; }
        set
        {
            _JokeService = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    private IOutputService? _OutService;
    public IOutputService OutService
    {
        get { return _OutService!; }
        set
        {
            _OutService = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    public Jester(IJokeService jokeService, IOutputService outService)
    {
        JokeService = jokeService;
        OutService = outService;
    }

    public virtual void TellJoke()
    {
        string joke;
        do{
            joke = JokeService.GetJoke();
        }while(joke.Contains("Chuck Norris"));
        OutService.DisplayJoke(joke);
    }


}

