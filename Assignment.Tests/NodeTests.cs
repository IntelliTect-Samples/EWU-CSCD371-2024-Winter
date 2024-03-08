using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{


    [TestMethod]
    public void GetEnumerator_ListOfFive_Successful() //IDK how else to test this 
    {
        Node<string> pets = new("dog");
        pets.Append("cat");
        pets.Append("fish");
        pets.Append("bird");
        pets.Append("snake");

        List<string> expected = ["dog", "cat", "fish", "bird", "snake"];
        List<string> actual = new List<string>(); // 2)
        foreach(Node<string> node in pets)
        {
            actual.Add(node.Data);
        }

        CollectionAssert.AreEqual(expected, actual); // 2)
        
        //var result = pets.GetEnumerator();
        //int count = 0;
        //while (result.MoveNext()) count++;

        Assert.AreEqual(5, pets.Count()); // 1)
        
    }

    [TestMethod]
    public void ChildItems_ReturnMaximumOfThree_Success()
    {
        Node<string> pets = new("dog");
        pets.Append("cat");
        pets.Append("fish");
        pets.Append("bird");
        pets.Append("snake");

        List<string> expected = ["cat", "fish", "bird"];

        var result = pets.ChildItems(3);

        Assert.IsTrue(expected.SequenceEqual<string>(result.Select(node => node.Data)));
    }


    // Below are just tests from Assignment 5

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
}

