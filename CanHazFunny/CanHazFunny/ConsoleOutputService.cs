using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

internal sealed class ConsoleOutputService : IOutputService
{
    public void WriteJoke(string joke)
    {
        Console.WriteLine(joke);
    }
}
