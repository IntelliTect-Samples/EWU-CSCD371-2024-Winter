﻿namespace CanHazFunny;

class Program
{
    static void Main(string[] args)
    {
        Jester jester = new(new JokeOutput, new JokeService());
        jester.TellJokey();
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester( new SomeReallyCoolOutputClass(), new SomeJokeServiceClass() ).TellJoke();
    }
}
