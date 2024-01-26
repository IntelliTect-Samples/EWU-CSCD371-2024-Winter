using System;


namespace CanHazFunny
{
    public class OutputToScreen : IOutputToScreen
    {
        public void WriteJokeToScreen(string joke)
        {
            Console.Write(joke);
        }
    }
}
