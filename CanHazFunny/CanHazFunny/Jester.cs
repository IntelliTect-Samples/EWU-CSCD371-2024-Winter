using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;


public class Jester(IJokeService? jokeService, IOutputService? outputService)
{
    private readonly IJokeService _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    private readonly IOutputService _outputService = outputService ?? throw new ArgumentNullException(nameof(outputService));

    public void TellJoke()
    {
        string joke;
        do
        {
            joke = _jokeService.GetJoke();
        } while (joke.Contains("Chuck Norris"));

        _outputService.WriteJoke(joke);
    }
}
