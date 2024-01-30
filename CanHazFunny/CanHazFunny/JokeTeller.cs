﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class JokeTeller: IJokeOutput
    {
        public string Joke { get; set; } = "";

        public void TellJoke()
        {
            Console.WriteLine(Joke);
        }
    }
}
