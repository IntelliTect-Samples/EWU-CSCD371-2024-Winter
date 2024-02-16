using Xunit;

namespace GenericsHomework.Tests;

    public class VennDiagramTests
    {
        [Fact]
        public void Constructor_ValidItem_SetsDataSuccessfully()
        { 

            Circle<string> circle1 = new("Circle1");
            Circle<string> circle2 = new("Circle2");

            // Act
            VennDiagram<string> venn = new("TestData",[circle1, circle2]);

            // Check if circles are set correctly
            Assert.Equal(2, venn.Circles.Count); // Check the count of circles
            Assert.Contains(circle1, venn.Circles); // Check if circle1 is present
            Assert.Contains(circle2, venn.Circles); // Check if circle2 is present
        }
        [Fact]
        public void AddCircles_NullCircle_ThrowsNullException()
        {
            Assert.Throws<ArgumentNullException>(() => { new VennDiagram<string>("TestData",[new Circle<string>("Circle3")]).AddCircles(null!); });
        }
        [Fact]
        public void AddCircles_ValidCircles_AddsSuccessfully()
        {
            // Arrange
            Circle<string> circleOne = new("Circle4");
            VennDiagram<string> vennDiagram = new("ValidData", [circleOne]);

            // Act
            Circle<string> circleTwo = new("Circle5");
            vennDiagram.AddCircles(circleTwo);

            // Assert
            Assert.Contains(circleTwo, vennDiagram.Circles);
        }

    [Fact]
    public void ToString_NullCircle_PrintsCorrectly()
    {

        VennDiagram<string> vennDiagram = new("TestData");

        // Assert
        Assert.Equal($"TestData: {{}}", vennDiagram.ToString());
    }

    [Fact]
    public void ToString_ValidCircles_PrintsCorrectly()
    {
        Circle<string> circle1 = new("Test1", ["Hi","Hello"]);
        Circle<string> circle2 = new("Test2", ["Bojour", "Ahola"]);

        List<Circle<string>> circles = [circle1, circle2];
        VennDiagram<string> vennDiagram = new("TestData",circles);

        // Assert
        Assert.Equal($"{circle1}, {circle2}", vennDiagram.ToString());
    }

    [Fact]
    public void Intersect_ValidCircles_ReturnsCircle()
    {
        Circle<string> colorCircle = new("Colors", ["Green", "Blue", "Orange"]);
        Circle<string> flavorCircle = new("Flavors", ["Grape", "Apple", "Orange"]);

        VennDiagram<string> vennDiagram = new("Colors And Tastes", [colorCircle,flavorCircle]);

        // Assert
        Circle<string> objectsCircle = vennDiagram.Intersection("Colors","Flavors");
    }
}

    

