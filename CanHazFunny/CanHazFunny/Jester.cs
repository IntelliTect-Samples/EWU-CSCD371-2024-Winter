using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester : IJokeService, IOutputToScreen
    {
        private readonly IJokeService IJokeDependency;
        private readonly IOutputToScreen IOutputDependency;
        private HttpClient HttpClient { get; } = new();



        public Jester(IJokeService IJokeDependency, IOutputToScreen IOutputDependency)
        {
            IJokeDependency = IJokeDependency ?? throw new ArgumentNullException(nameof(IJokeDependency));
            IOutputDependency = IOutputDependency ?? throw new ArgumentNullException(nameof(IOutputDependency));
            this.IJokeDependency = IJokeDependency;
            this.IOutputDependency = IOutputDependency;

        }

        public string GetJoke()
        {
            JokeService jokeService = new JokeService(HttpClient);
            string joke = jokeService.GetJoke();
            if (joke == null)
                throw new ArgumentNullException();
            return joke;
        }


        private string GetJokeDependency(IJokeService jokeDependency)
        {
            throw new NotImplementedException();
        }
        public object GetOutputDependency()
        {
            throw new NotImplementedException();
        }

        public void TellJoke()
        {
            JokeService _jokeService = new JokeService(HttpClient);
            string joke = _jokeService.GetJoke();
            if (joke.Contains("Chuck Norris"))
            {
                joke = _jokeService.GetJoke();
                TellJoke();
            }
            else
            {
                IOutputDependency.WriteJokeToScreen(joke);
            }
        }

        public void WriteJokeToScreen(string joke)
        {
            Console.Write(joke);
        }
    }
    
}
