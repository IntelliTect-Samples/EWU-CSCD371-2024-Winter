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
        Node<int> node = new(1);
        node.Append(2);
        Assert.NotEqual(node.Data, node.Next.Data);
    }

    [Fact]
    public void Node_NextPointToTheLastNode_Success()
    {
        Node<double> node = new(1.0);
        node.Append(2.0);
        node.Append(3.0);
        Assert.Equal(2.0, node.Next.Next.Data);
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
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.True(node.Exists(3));
    }

    [Fact]
    public void Exists_NodeDoesNotContainsData_True()
    {
        Node<double> node = new(1.1);
        node.Append(2.2);
        node.Append(3.3);
        Assert.False(node.Exists(4.4));
    }

    [Fact]
    public void ToString_PrintList_Success()
    {
        Node<string> node = new("Inigo Montoya");
        node.Append("Butter Cup");
        node.Append("Prince Johan");
        Assert.Equal("Linked List: Node 1: Inigo Montoya, Node 2: Prince Johan, Node 3: Butter Cup, }", node.ToString());
    }

    [Fact]
    public void Append_ExistedValue_ThrowArgumentException()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        Assert.Throws<ArgumentException>(
            () => node.Append(1));

    }

    [Fact]
    public void Clear_NodesDeleted_Successful()
    {
        Node<double> node = new(1.1);
        node.Append(2.1);
        node.Append(3.1);
        node.Clear();
        Assert.Equal(node.Data, node.Next.Data);
    }
}