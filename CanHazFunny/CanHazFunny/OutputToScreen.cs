using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
