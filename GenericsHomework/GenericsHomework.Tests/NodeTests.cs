using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void Node_CreateNodeWithDataAndNoNextReference_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => new Node<string>("Inigo Montoya", null!));
    }

    [Fact]
    public void Node_NextReferenceSet_Success()
    {
        Node<string> node = new("Inigo Montoya", node);
    }
}