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
        Assert.NotEqual(node.Data, node.Next.Data);
    }

    [Fact]
    public void Node_NextPointToTheLastNode_Success()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        node.Append("Prince Johan");
        Assert.Equal("Prince Johan", node.Next.Next.Data);
    }

    [Fact]
    public void Node_NextReferencePointToFistNode_Success()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        Assert.Equal("Inigo Montoya", node.Next.Next.Data);
    }

    [Fact]
    public void Exists_NodeContainsData_True()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        node.Append("Prince Johan");
        Assert.True(node.Exists("Prince Johan"));
    }

    [Fact]
    public void Exists_NodeDoesNotContainsData_True()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        node.Append("Prince Johan");
        Assert.False(node.Exists("Princes Bumble Gum"));
    }
}