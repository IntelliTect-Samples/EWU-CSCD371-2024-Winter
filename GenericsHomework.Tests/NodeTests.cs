using Xunit; 

namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void SingleNodePointsToItself()
    {
        // Arrange
        Node<string> newNode = new Node<string>("Hiiii");

        // Act - Nothing to act on for this test

        // Assert
        Assert.NotNull(newNode.Next); // Ensure Next property is not null
        Assert.Same(newNode, newNode.Next); // Ensure Next property points to itself
    }
}
