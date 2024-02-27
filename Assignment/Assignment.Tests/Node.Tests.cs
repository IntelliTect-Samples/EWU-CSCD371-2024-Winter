using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [Fact]
    public void Append_SingleItem_Succeed()
    {
        Node<int> node = new(1);
        var expected = new[] { 1 };

        Assert.Equals(expected, node);
    }

    [Fact]
    public static void Append_MultipleItems_Succeed()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        var expected = new[] { 1, 2, 3 };

        Assert.Equals(expected, node);
    }

    [Fact]
    public static void Exists_ItemExists_ReturnsTrue()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        Assert.IsTrue(node.Exists(2));
    }

    [Fact]
    public static void Exists_ItemNotExist_ReturnsFalse()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        Assert.IsFalse(node.Exists(4));
    }

    [Fact]
    public static void ChildItems_ReturnsCorrect_Succeed()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);

        var expected = new[] { 2, 3 };
        var res = node.ChildItems(2).ToArray();

        Assert.Equals(expected, res);
    }

    [Fact]
    public static void Clear_Clears_Success()
    {
        Node<int> node = new(1);
        node.Append(2);
        node.Clear();
        var expected = new[] { 2 };

        Assert.Equals(expected, node);
    }
}
