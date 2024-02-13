namespace GenericsHomework.Tests;
    public class NodeTests
    {
       [Fact]
        public void Node_SingleNode_PointsToSelf()
            {
                // Arrange
                Node<string> newNode = new Node<string>("hola");

                // Act - Nothing to act on for this test

                // Assert
                Assert.NotNull(newNode.Next); // Ensure Next property is not null
                Assert.Equal(newNode, newNode.Next); // Ensure Next property points to itself
            }
    }
