﻿namespace CanHazFunny;

public class Program
{
    public static void Main(string[] args)
    {
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
        Jester jester = new(new JokeService(), new OutputJoke());
        jester.TellJoke();
        jester.TellJoke();
        jester.TellJoke();
    }
}
