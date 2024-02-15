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
       public void  Constructor_ValidName_SetsNameSuccessfully()
        {
            Circle<string> circle = new Circle<string>("Johanne");
            Assert.Equal("Johanne", circle.Name);

        }
        [Fact]
        public void Add_MoreCircles_AddsSuccesfully()
        {
            Circle<string> circle = new Circle<string>("Alexa");
            circle.Add("Darrington");
            Assert.Equal("Darrington", circle.Elements!.Data);

        }

    }
}
