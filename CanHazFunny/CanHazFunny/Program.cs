namespace CanHazFunny;

public class Program
{
    public static void Main(string[] args)
    {
        //Feel free to use your own setup here - this is just provided as an example
        JokeService jokeService = new();
        JokeOutput jokeOutput = new();
        Jester jester = new(jokeService, jokeOutput);
        jester.TellJoke();
    }
}