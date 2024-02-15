using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericsHomework.Tests
{
    public class CircleTests
    {
        [Fact]
        public void Name_ValidName_SetSuccessfully()
            {
            Circle<string> circle = new("Johanne");
            Assert.Equal("Johanne", circle.Name());
        }
    

    }
}
