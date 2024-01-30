namespace CanHazFunny;

internal class Program
{
    public static void Main(string[] args)
    {
        JokeService jokeService = new();
        JokeOutput jokeOutput = new();
        Jester jester = new(jokeOutput, jokeService);
        jester.TellJoke();
    }
}
