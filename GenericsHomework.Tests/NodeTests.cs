using Xunit;

namespace GenericsHomework.Tests;

//Reminder: For this assignment, always use Assert.AreEqual<T>() (the generic version)

public class NodeTests
{
    [Fact]
    public void Next_OneNodeLoopsOnItself_Equal()
    {//Node not recognized
        Node<int> node = new(3);
        Assert.Equal(node.Data, node.Next.Data);
    }

    [Fact]
    public void Append_AddNodeWithDiffValue_NotEqual()
    {
        Node<int> node = new(3);
        node.Append(5);
        Assert.NotEqual(node, node.Next);
    }

    [Fact]
    public void Next_LoopsAroundToSelf_Equal()
    {
        Node<int> node = new(3);
        node.Append(5);
        Assert.Equal(node, node.Next.Next);
    }

    [Fact]
    public void Exists_CheckValueThatIsInList_True()
    {
        Node<string> node = new("apple");
        node.Append("pear");
        node.Append("orange");
        Assert.True(node.Exists("pear"));
    }

    [Fact]
    public void Exists_CheckValueThatIsNotInList_False()
    {
        Node<string> node = new("apple");
        node.Append("pear");
        node.Append("orange");
        Assert.False(node.Exists("cheese"));
    }

    [Fact]
    public void Append_TryToAppendDuplicate_ThrowException()
    {
        Node<int> node = new(3);
        node.Append(5);
        node.Append(7);
        Assert.Throws<ArgumentException>(() => node.Append(3));
    }

    [Fact]
    public void Append_TryToAppendNullValue_ThrowException()
    {
        Node<string> node = new("apple");
        node.Append("pear");
        node.Append("orange");
        Assert.Throws<ArgumentNullException>(() => node.Append(null!));
    }

    [Fact]
    public void Clear_CreateListAndClear_HeadShouldRemain()
    {
        Node<string> node = new("apple");
        node.Append("pear");
        node.Append("orange");

        //Verify the list has all items above
        Assert.Equal("apple",node.Data);
        Assert.Equal("pear", node.Next.Data);
        Assert.Equal("orange", node.Next.Next.Data);

        Assert.True(node.Exists("apple"));
        Assert.True(node.Exists("pear"));
        Assert.True(node.Exists("orange"));

        //Clear the list and verify only start remains
        node.Clear();
        Assert.Equal("apple", node.Data);
        Assert.NotEqual("pear", node.Next.Data);
        Assert.NotEqual("orange", node.Next.Next.Data);

        Assert.True(node.Exists("apple"));
        Assert.False(node.Exists("pear"));
        Assert.False(node.Exists("orange"));

        //TODO: add tests for ToString
    }

    [Fact]
    public void ToString_NullData_ThrowsException()
    {
        Node<string> node = new(null!);
        Assert.Throws<ArgumentNullException>(() => node.ToString());
    }

    [Fact]
    public void ToString_Data_ReturnsSuccessful()
    {
        Node<string> node = new("Hello there");
        Assert.Equal("Hello there", node.ToString());
    }

}

