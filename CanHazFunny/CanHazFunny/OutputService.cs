﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class OutputService : IOutPutJoke
    {
        public void Print(string Joke)
        {
            Console.WriteLine(Joke);

        }
    }
}
