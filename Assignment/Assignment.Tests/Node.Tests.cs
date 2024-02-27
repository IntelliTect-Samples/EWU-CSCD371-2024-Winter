using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Append_SingleItem_Succeed()
    {
        Node<int> node = new(1);
        node.Append(2);
        var expected = new[] { 1, 2 };
        var actual = node.ToArray();

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Append_MultipleItems_Succeed()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        var expected = new[] { 1, 2, 3 };
        var actual = node.ToArray();

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Exists_ItemExists_ReturnsTrue()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        Assert.IsTrue(node.Exists(2));
    }

    [TestMethod]
    public void Exists_ItemNotExist_ReturnsFalse()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        Assert.IsFalse(node.Exists(4));
    }

    [TestMethod]
    public void ChildItems_ReturnsCorrect_Succeed()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        var expected = new[] { 2, 3 };
        var res = node.ChildItems(2).ToArray();

        CollectionAssert.AreEqual(expected, res);
    }

    [TestMethod]
    public void Clear_Clears_Success()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Clear();
        var expected = new[] { 1 };
        var res = node.ToArray();

        CollectionAssert.AreEqual(expected, res);
    }
}
