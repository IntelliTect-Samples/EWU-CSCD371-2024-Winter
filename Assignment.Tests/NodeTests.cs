using System;
using Xunit;

namespace Assignment.Tests;

public class NodeTests
{
    // NOTE: Had to remove Underscores from test method names as it was giving build error on git, we know they are needed but that us the solution to get passed that what I am guessing in unintended behavior.
    [Fact]
    public void InitDataHeadSuccessful()
    {
        Node<string> list = new("IAmHead");
        Assert.Equal("IAmHead", list.GetData());
    }
    [Fact]
    public void AppendAlreadyExistsThrowsException()
    {
        Node<string> list = new("IamHead");
        list.Append("Hola");
        Assert.Throws<ArgumentException>(() => list.Append("IamHead"));
        Assert.Throws<ArgumentException>(() => list.Append("Hola"));
    }

    [Fact]
    public void ExistsAlreadyExistsTrue()
    {
        Node<string> list = new("IamHead");
        bool exists = list.Exists("IamHead");
        Assert.True(exists);
    }

    [Fact]
    public void ExistsDoesNotExistsFalse()
    {
        Node<string> list = new("IamHead");
        bool exists = list.Exists("head");
        Assert.False(exists);
    }

    [Fact]
    public void ToStringValueToStringSuccess()
    {
        Node<string> list = new("start");
        Node<string> list2 = new("last");
        Assert.Equal("start", list.ToString());
        Assert.Equal("last", list2.ToString());
    }

    [Fact]
    public void ClearAllClearedSuccess()
    {
        Node<string> list = new("start");
        list.Append("nextnode");
        list.Append("next");
        list.Append("last");
        list.Clear();
        Assert.True(list.Next.Equals(list));
        Assert.Equal("start", list.GetData());
    }

    [Fact]
    public void ClearFromSize1ClearedSuccess()
    {
        Node<string> list = new("start");
        list.Clear();
        Assert.True(list.Next.Equals(list));
        Assert.Equal("start", list.Next.GetData());
    }

    [Fact]
    public void AppendNextNodeSuccessful()
    {
        Node<string> list = new("iamhead");
        list.Append("nextnode");
        Assert.Equal("nextnode", list.Next.GetData());
        list.Append("next");
        Assert.Equal("next", list.Next.GetData());
        list.Append("last");
        Assert.Equal("last", list.Next.GetData());
    }

    [Fact]
    public void AppendAlreadyExistsDoesntChangeOurNextNode()
    {
        Node<string> node = new("first");
        node.Append("hello");
        Assert.Equal("hello", node.Next.GetData());
        node.Append("bye");
        Assert.Equal("bye", node.Next.GetData());
        Assert.Throws<ArgumentException>(() => node.Append("first"));
        Assert.NotEqual("first", node.Next.GetData());
        Assert.Equal("bye", node.Next.GetData());
    }

    [Fact]
    public void toStringPrintToString()
    {
        Node<string> node = new("first");
        string txt = node.ToString();
        Assert.Equal("first", txt);
    }
#nullable enable
    [Fact]
    public void NullToStringThrowsException()
    {
        Node<string>? node = new(null!);
        Assert.Throws<ArgumentNullException>(() => node.ToString());
    }
#nullable disable
}


