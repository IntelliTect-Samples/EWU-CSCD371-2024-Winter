using System;

namespace CanHazFunny
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}