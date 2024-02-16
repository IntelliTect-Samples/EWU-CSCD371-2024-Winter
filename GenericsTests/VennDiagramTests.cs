using Xunit;

namespace GenericsHomework.Tests;

    public class VennDiagramTests
    {
        [Fact]
        public void Constructor_ValidItem_SetsDataSuccessfully()
        { 

            Circle<string> circle1 = new();
            Circle<string> circle2 = new();

            // Create a list of circles
            var circles = new List<Circle<string>> { circle1, circle2 };

            // Act
            VennDiagram<string> venn = new(circles, "TestData");

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
            var circle = new Circle<string>();
            var vennDiagram = new VennDiagram<string>(new List<Circle<string>> { circle }, "TestData");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => { vennDiagram.AddCircles(null!); });
        }
        [Fact]
        public void AddCircles_ValidCircles_AddsSuccessfully()
        {
            // Arrange
            Circle<string> circleOne = new Circle<string>();
            VennDiagram<string> vennDiagram = new VennDiagram<string>(new List<Circle<string>> { circleOne }, "ValidData");

            // Act
            Circle<string> circleTwo = new Circle<string>();
            vennDiagram.AddCircles(circleTwo);

            // Assert
            Assert.Contains(circleTwo, vennDiagram.Circles);
        }
/*        [Fact]
        public void ToString_ValidCircles_PrintsCorrectly()
        {
            Circle<string> circle1 = new Circle<string>();
            Circle<string> circle2 = new Circle<string>();

            List<Circle<string>> circles = new List<Circle<string>> { circle1, circle2 };
            VennDiagram<string> vennDiagram = new VennDiagram<string>(circles, "TestData");

            // Expected string representation
            string expectedString = $"{{{{Circle1}}, {{Circle2}}}}";

            // Act
            string result = vennDiagram.ToString();

            // Assert
            Assert.Equal(expectedString, result);
        }*/
}

    

