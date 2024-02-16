using Newtonsoft.Json.Bson;
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
        [Fact]
        public void AddCircles_NullCircle_ThrowsNullException()
        {
            // Arrange
            var circle = new Circle<string>("Michael");
            var vennDiagram = new VennDiagram<string>(new List<Circle<string>> { circle }, "TestData");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => { vennDiagram.AddCircles(null!); });
        }
        [Fact]
        public void AddCircles_ValidCircles_AddsSuccessfully()
        {
            // Arrange
            Circle<string> circleOne = new Circle<string>("Circle one");
            VennDiagram<string> vennDiagram = new VennDiagram<string>(new List<Circle<string>> { circleOne }, "ValidData");

            // Act
            Circle<string> circleTwo = new Circle<string>("Circle two");
            vennDiagram.AddCircles(circleTwo);

            // Assert
            Assert.Contains(circleTwo, vennDiagram.Circles);
        }
        [Fact]

        public void ToString_ValidCircles_PrintsCorrectly()
        { 
        Circle<string> circle1 = new Circle<string>("Circle1");
        Circle<string> circle2 = new Circle<string>("Circle2");

        List<Circle<string>> circles = new List<Circle<string>> { circle1, circle2 };
        VennDiagram<string> vennDiagram = new VennDiagram<string>(circles, "TestData");

        // Expected string representation
        string expectedString = $"{{{{Circle1}}, {{Circle2}}}}";

        // Act
        string result = vennDiagram.ToString();

        // Assert
        Assert.Equal(expectedString, result);
    }




}

    
}
