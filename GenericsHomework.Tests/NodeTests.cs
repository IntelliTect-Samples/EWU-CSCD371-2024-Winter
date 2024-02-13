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
        Node<String> node = new("apple");
        node.Append("pear");
        node.Append("orange");
        Assert.True(node.Exists("pear"));
    }

    [Fact]
    public void Exists_CheckValueThatIsNotInList_False()
    {
        Node<String> node = new("apple");
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


}

