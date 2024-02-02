
namespace CanHazFunny;

    public class Program
    {
        public static void Main(string[] args)
    {
        new Jester(new JokeService(), new OutputToScreen()).TellJoke();
    }
    }
