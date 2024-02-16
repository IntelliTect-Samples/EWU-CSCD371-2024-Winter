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
        VennDiagram<string> venn = new("TestData", [circle1, circle2]);

        // Check if circles are set correctly
        Assert.Equal(2, venn.Circles.Count); // Check the count of circles
        Assert.Contains(circle1, venn.Circles); // Check if circle1 is present
        Assert.Contains(circle2, venn.Circles); // Check if circle2 is present
    }
    [Fact]
    public void AddCircles_NullCircle_ThrowsNullException()
    {
        Assert.Throws<ArgumentNullException>(() => { new VennDiagram<string>("TestData", [new Circle<string>("Circle3")]).AddCircles(null!); });
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
        Circle<string> circle1 = new("Test1", ["Hi", "Hello"]);
        Circle<string> circle2 = new("Test2", ["Bojour", "Ahola"]);

        List<Circle<string>> circles = [circle1, circle2];
        VennDiagram<string> vennDiagram = new("TestData", circles);

        // Assert
        Assert.Equal($"{circle1}, {circle2}", vennDiagram.ToString());
    }

    [Fact]
    public void Intersection_ValidCirclesNames_ReturnsCircle()
    {
        Circle<string> colorCircle = new("Colors", ["Green", "Blue", "Orange"]);
        Circle<string> flavorCircle = new("Flavors", ["Grape", "Apple", "Orange"]);

        VennDiagram<string> vennDiagram = new("Colors And Tastes", [colorCircle, flavorCircle]);

        // Assert
        Circle<string> objectsCircle = vennDiagram.Intersection("Flavors And also a Color", "Colors", "Flavors");
        Assert.Single(objectsCircle.Elements);
        Assert.Contains("Orange", objectsCircle.Elements);

    }

    [Fact]
    public void Intersection_NullName_ThrowsArgumentNullException()
    {
        Circle<string> colorCircle = new("Colors", ["Green", "Blue", "Orange"]);
        Circle<string> flavorCircle = new("Shapes", ["Square", "Rectange", "Triangle"]);

        VennDiagram<string> vennDiagram = new("Colors and Shapes", [colorCircle, flavorCircle]);

        Exception execption = Assert.Throws<ArgumentNullException>(() => vennDiagram.Intersection(null!, "Flavors", "Colors"));
    }

    [Fact]
    public void Intersection_NullFirstCircleName_ThrowsArgumentNullException()
    {
        Circle<string> colorCircle = new("Colors", ["Green", "Blue", "Orange"]);
        Circle<string> flavorCircle = new("Shapes", ["Square", "Rectange", "Triangle"]);

        VennDiagram<string> vennDiagram = new("Colors and Shapes", [colorCircle, flavorCircle]);

        Exception execption = Assert.Throws<ArgumentNullException>(() => vennDiagram.Intersection("Shape and also a Color", null!, "Colors"));
    }

    [Fact]
    public void Intersection_NullSecondCircleName_ThrowsArgumentNullException()
    {
        Circle<string> colorCircle = new("Colors", ["Green", "Blue", "Orange"]);
        Circle<string> flavorCircle = new("Shapes", ["Square", "Rectange", "Triangle"]);

        VennDiagram<string> vennDiagram = new("Colors and Shapes", [colorCircle, flavorCircle]);

        Exception execption = Assert.Throws<ArgumentNullException>(() => vennDiagram.Intersection("Shape and also a Color", "Flavors", null!)) ;
    }

    [Fact]
    public void Intersection_InvalidFirstCircleName_ThrowsArgumentException()
    {
        Circle<string> colorCircle = new("Colors", ["Green", "Blue", "Orange"]);
        Circle<string> flavorCircle = new("Shapes", ["Square", "Rectange", "Triangle"]);

        VennDiagram<string> vennDiagram = new("Colors and Shapes", [colorCircle, flavorCircle]);

        Exception execption = Assert.Throws<ArgumentException>(() => vennDiagram.Intersection("Shape and also a Color", "Flavors", "Colors"));
        Assert.Equal("A non valid name for the first circle has been provided (Parameter 'firstCircleName')", execption.Message);
    }

    [Fact]
    public void Intersection_InvalidSecondCircleName_ThrowsArgumentException()
    {
        Circle<string> colorCircle = new("Colors", ["Green", "Blue", "Orange"]);
        Circle<string> shapeCircle = new("Shapes", ["Square", "Rectange", "Triangle"]);

        VennDiagram<string> vennDiagram = new("Colors and Shapes", [colorCircle, shapeCircle]);

        Exception execption = Assert.Throws<ArgumentException>(() => vennDiagram.Intersection("Shape and also a Color", "Shapes", "Dogs"));
        Assert.Equal("A non valid name for the second circle has been provided (Parameter 'secondCircleName')", execption.Message);
    }

}

    

