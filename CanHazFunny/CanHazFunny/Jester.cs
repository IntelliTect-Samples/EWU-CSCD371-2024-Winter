using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private IJokeService? _JokeService;

        public IJokeService JokeService
        {
            get { return _JokeService!; }
            set
            {
                _JokeService = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        private IOutJoke? _OutService;
        public IOutJoke OutService
        {
            get { return _OutService!; }
            set
            {
                _OutService = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Jester(IJokeService jokeService, IOutJoke outService)
        {
            JokeService = jokeService;
            OutService = outService;
        }
    }
}
