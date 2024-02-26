using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestFixture]
public class NodeTests
{
    [Test]
    public void Append_SingleItem_Succeed()
    {
        Node<int> node = new(1);
        var expected = new[] { 1 };

        Assert.Equals(expected, node);
    }

    [Test]
    public void Append_MultipleItems_Succeed()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        var expected = new[] { 1, 2, 3 };

        Assert.Equals(expected, node);
    }

    [Test]
    public void Exists_ItemExists_ReturnsTrue()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        Assert.That(node.Exists(2), Is.True);
    }

    [Test]
    public void Exists_ItemNotExist_ReturnsFalse()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        Assert.That(node.Exists(4), Is.False);
    }

    [Test]
    public void ChildItems_ReturnsCorrect_Succeed()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);

        var expected = new[] { 2, 3 };
        var res = node.ChildItems(2).ToArray();

        Assert.Equals(expected, res);
    }

    [Test]
    public void Clear_Clears_Success()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Clear();
        var expected = new[] { 2 };

        Assert.Equals(expected, node);
    }
}
