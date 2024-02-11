using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void Node_CreateNodeWithData_Success()
    {
        Node<string> node = new("Inigo");
        Assert.NotNull(node);
    }

    [Fact]
    public void Node_NextReferenceSet_Success()
    {
        Node<string> head = new("Inigo Montoya", head);
        Assert.Equal(head, head.Next);
    }
}