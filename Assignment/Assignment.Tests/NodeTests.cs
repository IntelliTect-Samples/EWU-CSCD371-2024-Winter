using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Exists_GivenNull_ThrowsArgumentNullException()
    {
        Node<string> n = new("n");
        Assert.ThrowsException<ArgumentNullException>(() => n.Exists(null!));
    }

    [TestMethod]
    public void Append_ThrowsNullIfExists()
    {
        Node<int> n = new(0);
        Assert.ThrowsException<ArgumentException>(() => n.Append(0));
    }

    [TestMethod]
    public void Append_IncreasesCount()
    {
        Node<int> node = new(0);
        int initial = node.Count();
        node.Append(1);
        Assert.AreEqual(initial + 1, node.Count());
    }

    [TestMethod]
    public void Append_ChangesLastNode()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);
        Assert.AreEqual(1, node.Value);
        Assert.AreEqual(2, node.Next.Value);
        Assert.AreEqual(3, node.Next.Next.Value);
        Assert.AreEqual(4, node.Next.Next.Next.Value);
    }

    [TestMethod]
    public void NodeAppend_LinqTest()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);
        node.Append(5);
        node.Append(6);
        int[] aggregate = (from n in node
            where n.Value > 2
            select n.Value).ToArray();
        string joined = string.Join(",", aggregate);
        Assert.AreEqual("3,4,5,6", joined);
    }

    [TestMethod]
    public void ChildItems_GetsNoMoreThanMax()
    {
        Node<int> node = new(0);
        node.Append(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);
        node.Append(5);
        node.Append(6);
        Assert.AreEqual(6, node.Count());
        Assert.AreEqual(4, node.ChildItems(4).Count());
    }
}
