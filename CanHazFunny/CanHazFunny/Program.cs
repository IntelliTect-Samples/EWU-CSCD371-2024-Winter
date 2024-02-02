using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

    public class Program
    {
        public static void Main(string[] args)
    {
        new Jester(new JokeService(), new OutputToScreen()).TellJoke();
    }
    }
