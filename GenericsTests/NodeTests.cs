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
    public void ToString_NullData_ThrowsNullRefernceException()
    {
        Assert.Throws<NullReferenceException>(() => new Node<object>(null!).ToString());
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
    public void Exists_NodeExistsAtEnd_ReturnsTrue()
    {
        Assert.True(NodeList.Exists("best!"));
    }

    [Fact]
    public void Exists_NodeExistsInMiddle_ReturnsTrue()
    {

        Assert.True(NodeList.Exists("the"));
    }

    [Fact]
    public void Exists_NodeExistsAtStart_ReturnsTrue()
    {
        Assert.True(NodeList.Exists("Alexa"));
    }

    [Fact]
    public void Exists_NodeDoesNotExists_ReturnsFalse()
    {
        Assert.False(NodeList.Exists("Reeehat"));
    }


}
