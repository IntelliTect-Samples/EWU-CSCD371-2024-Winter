using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public interface IJokeService
    {
         string GetJoke();
    }
}
