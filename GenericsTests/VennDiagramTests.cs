using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericsHomework.Tests
{
    public class VennDiagramTests
    {
        [Fact]
        public void Constructor_ValidItem_SetsDataSuccessfully()
        { 

            Circle<string> circle1 = new Circle<string>("Circle1");
            Circle<string> circle2 = new Circle<string>("Circle2");

            // Create a list of circles
            var circles = new List<Circle<string>> { circle1, circle2 };

            // Act
            VennDiagram<string> venn = new VennDiagram<string>(circles, "TestData");

            // Assert
            Assert.Equal("TestData", venn.Data);

            // Check if circles are set correctly
            Assert.Equal(2, venn.Circles.Count); // Check the count of circles
            Assert.Contains(circle1, venn.Circles); // Check if circle1 is present
            Assert.Contains(circle2, venn.Circles); // Check if circle2 is present
        }

    }

    
}
