namespace CanHazFunny;

class Program
{
    static void Main(string[] args)
    {
        new Jester(new JokeTeller(), new JokeService()).TellJoke();
    }
}
