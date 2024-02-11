using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{

    [Fact]
    public void Node_NextPointToItself_Success()
    {
        Node<string> node = new("Inigo Montoya", null!);
        Assert.Equal(node, node.Next);
    }

    [Fact]
    public void Node_NextReferencePointToSecondNode_Success()
    {
        Node<string> node = new("Inigo Montoya", null!);
        Node<string> node2 = new("Inigo Montoya", node);
        Assert.NotEqual(node2, node.Next);
    }
}