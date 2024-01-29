using System;

namespace CanHazFunny;


public class Jester
{
    private readonly IService JokeService;
    private readonly IOutput JokeOutput;

    public Jester(IService jokeService, IOutput jokeOutput)
    {
        this.JokeService = jokeService ?? throw new ArgumentNullException(nameof(JokeService));
        this.JokeOutput = jokeOutput ?? throw new ArgumentNullException(nameof(JokeOutput));

    }

    public void TellJoke()
    {
        string joke = JokeService.GetJoke();
        if (joke.Contains("Chuck Norris"))
        {
            TellJoke(); 
        }
        else
        {
            JokeOutput.WriteJoke(joke);
        }
    }

}


