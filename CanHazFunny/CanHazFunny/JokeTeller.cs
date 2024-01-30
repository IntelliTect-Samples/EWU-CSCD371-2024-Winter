using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    internal class JokeTeller: IJokeOutput
    {
        public string Joke { get; set; } = "";

        public void TellJoke()
        {
            Console.WriteLine(Joke);
        }
    }
}
