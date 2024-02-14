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

    [Fact]
    public void ToString_PrintList_Success()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        node.Append("Prince Johan");
        Assert.Equal("Linked List: Node 1: Inigo Montoya, Node 2: Butter Cup, Node 3: Prince Johan, }", node.ToString());
    }

    [Fact]
    public void Append_ExistedValue_ThrowArgumentException()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        node.Append("Prince Johan");
        Assert.Throws<ArgumentException>(
            () => node.Append("Inigo Montoya"));

    }

    [Fact]
    public void Clear_NodesDeleted_Successful()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        node.Append("Prince Johan");
        node.Clear();
        Assert.Equal(node.Data, node.Next.Data);
    }
}