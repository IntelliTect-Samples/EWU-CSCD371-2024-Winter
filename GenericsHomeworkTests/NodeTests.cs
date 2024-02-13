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
        Assert.Empty(firstNode);
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
        Assert.Throws<ArgumentException>(() => firstNode.Append(2));
        Assert.Throws<ArgumentException>(() => firstNode.Add(2));
    }

    [Fact]
    public void Contains_ReturnsTrueIfContains()
    {
        Node<int> firstNode = new(1);
        Assert.DoesNotContain(2, firstNode);
        Assert.Contains(1, firstNode);
        firstNode.Append(2);
        Assert.Contains(2, firstNode);
    }

    [Fact]
    public void Count_ReturnsCorrectValue()
    {
        Node<int> firstNode = new(1);
        Assert.Single(firstNode);
        firstNode.Append(2);
        firstNode.Append(3);
        Assert.Equal(3, firstNode.Count);
    }

    [Fact]
    public void CopyTo_ThrowsArgumentOutOfRangeException()
    {
        Node<int> firstNode = new(4);
        firstNode.Append(5);
        int[] ints = { 1, 2, 3 };
        Assert.Throws<ArgumentOutOfRangeException>(() => firstNode.CopyTo(ints, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => firstNode.CopyTo(ints, 2));
    }

    [Fact]
    public void CopyTo_CopiesValues()
    {
        Node<int> firstNode = new(5);
        firstNode.Append(6);
        firstNode.Append(7);
        int[] ints = { 0, 1, 2, 3, 4 };
        firstNode.CopyTo(ints, 1);
        int[] copied = { 0, 5, 6, 7, 4 };
        Assert.Equal(copied, ints);
    }
}
