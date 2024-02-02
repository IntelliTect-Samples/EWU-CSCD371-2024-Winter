using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CanHazFunny.Tests
{
    public class JokeServiceTests
    {
        [Fact]
        public void GetJoke_ReciveString_Success()
        {
            JokeService service = new JokeService();
            Assert.IsType<string>(service.GetJoke());
        }
    }
}
