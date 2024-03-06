using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Assignment.Test;

#pragma warning disable CS8618

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Next_NodeLoopsOnItself_Equal()
    {
        Node<int> node = new(3);
        Assert.AreEqual(node.Data, node.Next.Data);
    }

    [TestMethod]
    public void Append_Node_Equal()
    {
        Node<int> node = new(6);
        node.Append(7);
        Assert.AreEqual(7, node.Next.Data);
    }

    [TestMethod]
    public void Append_NodeWithDifferentValue_NotEqual()
    {
        Node<int> node = new(3);
        node.Append(5);
        Assert.AreNotEqual(node, node.Next);
    }

    [TestMethod]
    public void Next_LoopsAroundToSelf_Equal()
    {
        Node<int> node = new(3);
        node.Append(5);
        Assert.AreEqual(node, node.Next.Next);
    }

    [TestMethod]
    public void Exists_ValueInList_ReturnsTrue()
    {
        Node<string> node = new("apple");
        node.Append("pear");
        node.Append("orange");
        Assert.IsTrue(node.Exists("pear"));
    }

    [TestMethod]
    public void Exists_ValueInList_ReturnsFalse()
    {
        Node<string> node = new("apple");
        node.Append("pear");
        node.Append("orange");
        Assert.IsFalse(node.Exists("cheese"));
    }

    [TestMethod]
    public void Append_AppendsDuplicate_ThrowsException()
    {
        Node<int> node = new(3);
        node.Append(5);
        node.Append(7);
        Assert.ThrowsException<ArgumentException>(() => node.Append(3));
    }

    [TestMethod]
    public void Append_NullValue_ThrowsException()
    {
        Node<string> node = new("apple");
        node.Append("pear");
        node.Append("orange");
        Assert.ThrowsException<ArgumentNullException>(() => node.Append(null!));
    }

    [TestMethod]
    public void Clear_ClearsNewList_HeadRemains()
    {
        Node<string> node = new("apple");
        node.Append("pear");
        node.Append("orange");

        //Verify the list has all items above
        Assert.AreEqual("apple", node.Data);
        Assert.AreEqual("pear", node.Next.Data);
        Assert.AreEqual("orange", node.Next.Next.Data);

        Assert.IsTrue(node.Exists("apple"));
        Assert.IsTrue(node.Exists("pear"));
        Assert.IsTrue(node.Exists("orange"));

        //Clear the list and verify only start remains
        node.Clear();
        Assert.AreEqual("apple", node.Data);
        Assert.AreNotEqual("pear", node.Next.Data);
        Assert.AreNotEqual("orange", node.Next.Next.Data);

        Assert.IsTrue(node.Exists("apple"));
        Assert.IsFalse(node.Exists("pear"));
        Assert.IsFalse(node.Exists("orange"));
    }

    [TestMethod]
    public void ToString_Data_ReturnsSuccessful()
    {
        Node<string> node = new("Hello there");
        Assert.AreEqual("Hello there", node.ToString());
    }

    [TestMethod]
    public void GetEnumerator_AddElements_ReturnsSuccessful()
    {
        Node<string> node = new("Hello there");
        node.Append("General Kenobi");
        node.Append("You are a bold one");

        Assert.AreEqual(3, node.Count());
        Assert.IsTrue(new List<string> { "Hello there", "General Kenobi", "You are a bold one"}.SequenceEqual(node.Select(Node => Node.Data)));
    }

    [TestMethod]
    public void ChildItems_Input4SetMaxTo3_ReturnsSuccessful()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);

        Assert.AreEqual(4, node.Count());
        
        IEnumerable<Node<int>> result = node.ChildItems(3);
        
        Assert.IsTrue(new List<int> { 2, 3, 4}.SequenceEqual(result.Select(Node => Node.Data)));
        
         
    }
}
