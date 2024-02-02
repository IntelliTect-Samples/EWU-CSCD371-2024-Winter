namespace CanHazFunny;

class Program
{
    static void Main(string[] args)
    {
        Jester _jest = new (new JokeTeller(), new JokeService());
        _jest.TellJoke();
    }
}
