﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class JokeOutput : IJokeOutput
    {
        public void WriteJoke(string joke)
        {
            ArgumentNullException.ThrowIfNull(joke);

            Console.WriteLine(joke);
        }
    }
}
