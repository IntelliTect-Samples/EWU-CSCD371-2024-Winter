using Xunit;

namespace GenericsHomework.Tests;

public class VennDiagramTests
{

    public VennDiagram<string> VennDiagram { get;}

    public VennDiagramTests()
    {

        Circle<string> StudentCircle = new("Students", ["Harry", "Ron", "Hermione", "Troy", "Peter", "Johnny"]);
        Circle<string> WizardCircle = new("Wizards", ["Harry", "Ron", "Hermione", "Snape", "Dumbledore"]);
        Circle<string> NewYorkerCircle = new("New Yorkers", ["Peter", "Johnny", "Michaelangelo", "Tony", "Ross"]);
        Circle<string> SuperHeroCircle = new("Superheroes", ["Peter", "Tony", "Michaelangelo", "Steve", "Clark"]);

        VennDiagram = new VennDiagram<string>("Students, Wizards, New Yorkers, and Super Heroes", [StudentCircle, WizardCircle, NewYorkerCircle, SuperHeroCircle]);

    }

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
        // Assert
        Circle<string> objectsCircle = VennDiagram.Intersection("New York Superheros", "New Yorkers", "Superheroes");
        Assert.Equal(3,objectsCircle.Elements.Count);
        Assert.Contains("Peter", objectsCircle.Elements);
        Assert.Contains("Michaelangelo", objectsCircle.Elements);
        Assert.Contains("Tony", objectsCircle.Elements);

    }

    [Fact]
    public void Intersection_NullName_ThrowsArgumentNullException()
    {

        Exception execption = Assert.Throws<ArgumentNullException>(() => VennDiagram.Intersection(null!, "New Yorkers", "Superheroes"));
    }

    [Fact]
    public void Intersection_NullFirstCircleName_ThrowsArgumentNullException()
    {
        Exception execption = Assert.Throws<ArgumentNullException>(() => VennDiagram.Intersection("Null Wizards", null!, "Wizards"));
    }

    [Fact]
    public void Intersection_NullSecondCircleName_ThrowsArgumentNullException()
    {
        Exception execption = Assert.Throws<ArgumentNullException>(() => VennDiagram.Intersection("Null Wizards", "Wizards", null!)) ;
    }

    [Fact]
    public void Intersection_InvalidFirstCircleName_ThrowsArgumentException()
    {

        Exception execption = Assert.Throws<ArgumentException>(() => VennDiagram.Intersection("California Wizards", "Calfornians", "Wizards"));
        Assert.Equal("A non valid name for the first circle has been provided (Parameter 'firstCircleName')", execption.Message);
    }

    [Fact]
    public void Intersection_InvalidSecondCircleName_ThrowsArgumentException()
    {
        Exception execption = Assert.Throws<ArgumentException>(() => VennDiagram.Intersection("Student Robots", "Students", "Robots"));
        Assert.Equal("A non valid name for the second circle has been provided (Parameter 'secondCircleName')", execption.Message);
    }

}

    

