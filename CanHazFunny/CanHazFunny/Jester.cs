using System;

namespace CanHazFunny;


public class Jester(IJokeService jokeServiceInterface, IJokeOutput jokeOutputInterface)
{
    private IJokeService jokeService = jokeServiceInterface ?? throw new ArgumentNullException(nameof(jokeServiceInterface));

    private IJokeOutput jokeOutput = jokeOutputInterface ?? throw new ArgumentNullException(nameof(jokeOutputInterface));


    
}