using Newtonsoft.Json.Bson;
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
        public void Constructor_ValidItem_SetsDataSuccessfully()
        {
            Circle<string> circle = new Circle<string>("Johanne");
            Assert.Equal("Johanne", circle.Data);

        }
        [Fact]
        public void Add_NullElement_ThrowsNullException()
        {
            Circle<string> circle = new Circle<string>("Circle");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => circle.Add(null!));

        }
        [Fact]
        public void Add_MoreCircles_AddsSuccesfully()
        {
            Circle<string> circle = new Circle<string>("Alexa");
            circle.Add("Darrington");
            Assert.Equal("Darrington", circle.Elements.Next.Data);

        }
        [Fact]
        public void ToString_ValidData_PrintsSuccessfully()
        {
            Circle<string> circle = new Circle<string>("Benjamin");
            Assert.Equal("Benjamin", circle.ToString());
            circle.Add("Rocks!");
            Assert.Equal("Rocks!", circle.Elements.Next.Data);

        }

    }
}
