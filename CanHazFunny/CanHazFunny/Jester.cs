using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester : IJoke,IOutputToScreen
    {
        private readonly IJoke _IJokeDependency;
        private readonly IOutputToScreen _IOutputDependency;


        public Jester(IJoke IJokeDependency, IOutputToScreen IOutputDependency)
            {
                _IJokeDependency = IJokeDependency;
            _IOutputDependency = IOutputDependency;
            }

        public string GetJoke()
        {
            throw new NotImplementedException();
        }

        public object GetJokeDependency()
        {
            throw new NotImplementedException();
        }

        public object GetOutputDependency()
        {
            throw new NotImplementedException();
        }

        public void TellJoke()
        {
            throw new NotImplementedException();
        }

        public void WriteJokeToScreen(string joke)
        {
            throw new NotImplementedException();
        }
    }

    
}
