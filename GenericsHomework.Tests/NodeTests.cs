using Xunit;

namespace GenericsHomework.Tests;

//Reminder: For this assignment, always use Assert.AreEqual<T>() (the generic version)

public class NodeTests
{
    [Fact]
    public void Node_OneNodeLoopsOnItself_Equal()
    {
        Node<int> node = new(3);
        Assert.Equal(node.Data, node.Next.Data);
    }

    [Fact]
    public void Node_MultipleNodes_NotEqual()
    {
        Node<int> node = new(3);
        node.Append(5);
        Assert.NotEqual(node, node.Next);
    }

    [Fact]
    public void Node_LoopsAroundToSelf_Equal()
    {
        Node<int> node = new(3);
        node.Append(5);
        Assert.Equal(node, node.Next.Next);
    }
}

