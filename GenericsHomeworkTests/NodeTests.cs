using GenericsHomework;
using Xunit;

namespace GenericsHomeworkTests;
public class NodeTests
{
    [Fact]
    public void Node_WithIntegerValue_HasCorrectValue()
    {
        Node<int> node = new(5);
        Assert.Equal(5, node.Value);
    }
    [Fact]
    public void Node_ToString_ReturnsCorrectStringRepresentation()
    {
        Node<string> node = new("Hello");
        Assert.Equal("Hello", node.ToString());
    }
    [Fact]
    public void Append_AddsNewNodeAfterCurrentNode()
    {
        Node<int> firstNode = new(1);
        firstNode.Append(2);
        Assert.Equal(2, firstNode.Next.Value);
    }
    [Fact]
    public void Clear_RemovesAllNodesExceptCurrentNode_Successful()
    {
        Node<int> firstNode = new(1);
        firstNode.Append(2);
        firstNode.Append(3);

        firstNode.Clear();

        Assert.Equal(firstNode, firstNode.Next);
    }
    [Fact]
    public void Exists_ReturnsTrueIfValueExistsInList()
    {
        Node<int> firstNode = new(1);
        firstNode.Append(2);
        firstNode.Append(3);

        Assert.True(firstNode.Exists(2));
    }
    [Fact]
    public void Exists_ReturnsFalseIfValueDoesNotExistInList()
    {
        Node<int> firstNode = new(1);
        firstNode.Append(2);
        firstNode.Append(3);

        Assert.False(firstNode.Exists(4));
    }
    [Fact]
    public void Append_ThrowsExceptionIfDuplicateValueIsAppended()
    {
        Node<int> firstNode = new(1);
        firstNode.Append(2);

        Assert.Throws<System.ArgumentException>(() => firstNode.Append(2));
    }
}
