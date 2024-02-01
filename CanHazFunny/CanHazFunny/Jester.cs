using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;


public class Jester
{
    private IJokeService JokeService {  get; set; }
    private IOutputService OutputService { get; set; }

    public Jester(IJokeService jokeService, IOutputService outputService)
    {
        ArgumentNullException.ThrowIfNull(jokeService);
        ArgumentNullException.ThrowIfNull(outputService);

        JokeService = jokeService;
        OutputService = outputService;
    }

    public void TellJoke()
    {
        string joke;
        do
        {
            joke = JokeService.GetJoke();
        } while (joke.Contains("Chuck Norris"));

        OutputService.WriteJoke(joke);
    }
}
