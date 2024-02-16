using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{

    public Node<string> NodeList { get; }

    public NodeTests() {
        NodeList = new("Alexa");
        NodeList.Append("is");
        NodeList.Append("the");
        NodeList.Append("best!");
    }

    [Fact]
    public void ToString_NullData_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => new Node<object>(null!).ToString());
    }

    [Fact]
    public void ToString_ValidData_ReturnsStringSuccesfully()
    {
        Assert.Equal("Alexa", NodeList.ToString());
        Assert.Equal("is", NodeList.Next.ToString());

    }

    [Fact]
    public void Append_AddedNodes_SuccesfullyReturnsValue()
    {
        Node<string> newNode = new("Hiiii");
        newNode.Append("You rock");
        newNode.Append("!");

        Assert.Equal("You rock", newNode.Next.Data);
        Assert.Equal("!", newNode.Next.Next.Data);

    }
    [Fact]
    public void Append_DuplicateNodeValue_ThrowsInvalidOperationException()
    {
        Node<string> newNode = new("Copy");
        Assert.Throws<InvalidOperationException>(() => newNode.Append("Copy"));

    }

    [Fact]
    public void Clear_ManyNodes_SuccessfullyClears()
    {
        Node<string> newNode = new("Lets goo");
        newNode.Append("New Node1");
        newNode.Append("New Node2");
        newNode.Clear();

        Assert.Same(newNode, newNode.Next);
    }

    [Theory]
    [InlineData("best!")]
    [InlineData("the")]
    [InlineData("Alexa")]
    public void Exists_NodeExists_ReturnsTrue(string data)
    {
        Assert.True(NodeList.Exists(data));
    }


    [Fact]
    public void Exists_NodeDoesNotExists_ReturnsFalse()
    {
        Assert.False(NodeList.Exists("Rahat"));
    }


}
