using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;


public class Jester
{
    //private const string NameToAvoid = "chuck norris";

    // readonly IJokeOutput? output;
    private OutputtingJoke? Output;
    private JokeService? OurService;

    public Jester(JokeService? service, OutputtingJoke? output)
    {
        ArgumentNullException.ThrowIfNull(service, nameof(service));
        ArgumentNullException.ThrowIfNull(output, nameof(output));
        this.Output = output;
        this.OurService = service;
    }
   

    public void TellJoke()
    {
        string theJoke = "";

        do
        {
          theJoke = OurService!.GetJoke();
        } while (theJoke.Contains("Chuck Norris", StringComparison.OrdinalIgnoreCase));

        Output!.PrintingJokeyJoke(theJoke);
    }
}
