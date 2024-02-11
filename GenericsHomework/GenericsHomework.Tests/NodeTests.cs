using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{

    [Fact]
    public void Node_NextPointToItself_Success()
    {
        Node<string> node = new("Inigo Montoya");
        Assert.Equal(node, node.Next);
    }

    [Fact]
    public void Node_NextReferencePointToSecondNode_Success()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        Assert.NotEqual(node.Data, node.Next.Next.Data);
    }

    [Fact]
    public void Node_NextReferenceThreeNodes_Success()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        node.Append("Prince Johan");
        Assert.NotEqual(node.Data, node.Next.Next.Data);
    }
}