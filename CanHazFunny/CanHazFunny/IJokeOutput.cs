using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    interface IJokeOutput
    {
        //string Output { get; }
        public void PrintingJoke(string jokePrint)
        {
            Console.WriteLine(jokePrint);
        }
    }
}