using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void Constructor_CorrectInput_SetsValues()
    {
        Node<int> node = new(5);
        Assert.Equal(5, node.Data);
    }

    [Fact]
    public void ToString_ReturnsCorrect()
    {
        Node<int> node = new(10);
        string res = node.ToString();
        Assert.Equal("10", res);
    }

    [Fact]
    public void Append_AddingNode_AddsNode()
    {
        Node<int> node = new(1);
        node.Append(2);
        Assert.Equal(2, node.Next.Data);
    }

    [Fact]
    public void Clear_NodePointsToSelf()
    {
        Node<int> node = new(1);
        node.Clear();
        Assert.True(object.ReferenceEquals(node, node.Next));
    }

    [Fact]
    public void Next_InitiallyPointsToSelf()
    {
        Node<int> node = new(1);
        Assert.True(object.ReferenceEquals(node, node.Next));
    }

    [Fact]
    public void Exists_ValueExists_ReturnsTrue()
    {
        Node<int> node = new(1);
        bool exists = node.Exists(1);
        Assert.True(exists);
    }

    [Fact]
    public void Exists_ValueNotExists_ReturnsFalse()
    {
        Node<int> node = new(1);
        Assert.False(node.Exists(2));
    }

    [Fact]
    public void Append_DuplicateValue_ThrowsError()
    {
        Node<int> node = new(1);
        node.Append(2);

        Exception exception = Assert.Throws<ArgumentException>(() => node.Append(2));
        Assert.Contains("Duplicate Value cannot be added.", exception.Message);
    }

    [Fact]
    public void Constructor_Null_ValueNull()
    {
        Node<string> node = new(null!);
        Assert.Null(node.Data);
    }

    [Fact]
    public void Append_Null_ValueNull()
    {
        Node<string> node = new("first");
        node.Append(null!);

        Assert.Null(node.Next.Data);
    }

    [Fact]
    public void Exists_NullValue_ReturnsTrue()
    {
        Node<string> node = new(null!);
        node.Append("second");

        bool exists = node.Exists(null!);
        Assert.True(exists);
    }

    [Fact]
    public void Exists_NullNotThere_ReturnsFalse()
    {
        Node<string> node = new("first");
        node.Append("second");

        bool exists = node.Exists(null!);

        Assert.False(exists);
    }

    [Fact]
    public void Append_DuplicateNull_ThrowsError()
    {
        Node<string> node = new(null!);
        node.Append("second");

        Exception exception = Assert.Throws<ArgumentException>(() => node.Append(null!));
        Assert.Contains("Duplicate Value cannot be added.", exception.Message);
    }
}