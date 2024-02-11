using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void ToString_NullData_ThrowsException()
    {
        Assert.Throws<NullReferenceException>(() => new Node<object>(null!).ToString());
    }

    [Fact]
    public void ToString_ValidData_ReturnsStringSuccesfully()
    {
        Node<string> newNode = new("Benjamin");
        newNode.Append("rocks!");
        Assert.Equal("Benjamin", newNode.ToString());
        Assert.Equal("rocks!", newNode.Next.ToString());

    }

    [Fact]
    public void Append_AddedNodes_SuccesfullyReturnsValue()
    {
        Node<string> newNode = new("Hiiii");
        newNode.Append("You rock");

        Assert.Equal("You rock", newNode.Next.Data);

    }
    [Fact]
    public void Append_DuplicateNodeValue_ThrowsArgumentException()
    {
        Node<string> newNode = new("Copy");
        Assert.Throws<ArgumentException>(() => newNode.Append("Copy"));

    }

    [Fact]
    public void Clear_ManyNodes_SuccessfullyClears()
    {
        Node<string> newNode = new("Lets goo");
        newNode.Append("New Node1");
        newNode.Append("New Node2");
        newNode.Clear();

        Assert.Equal(newNode, newNode.Next);
    }

    [Fact]
    public void Exists_NodeExists_ReturnsTrue()
    {
        Node<string> newNode = new("Johanne");
        newNode.Append("is");
        newNode.Append("the");
        newNode.Append("best!");

        Assert.True(newNode.Exists("best!"));
    }

    [Fact]
    public void Exists_NodeDoesNotExists_ReturnsFalse()
    {
        Node<string> newNode = new("Johanne");
        newNode.Append("is");
        newNode.Append("the");
        newNode.Append("best!");

        Assert.False(newNode.Exists("Reeehat"));
    }


}
