﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;


public class Jester 
{
    

    // readonly IJokeOutput? output;
    private IJokeOutput Output;
    private IJokeService OurService;

    public Jester(IJokeService service, IJokeOutput output)
    {
        ArgumentNullException.ThrowIfNull(service);
        ArgumentNullException.ThrowIfNull(output);
        Output = output;
        OurService = service;
    }
   

    public void TellJoke()
    {
        string _theJoke;
        do
        {
          _theJoke = OurService.GetJoke();
        } while (_theJoke.Contains("Chuck Norris"));

        Output.PrintingJokeyJoke(_theJoke);
    }
}
