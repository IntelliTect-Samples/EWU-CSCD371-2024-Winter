using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{

    // NodeList will contain non nullable values but its set in TestInitialize method
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Node<string> NodeList { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    [TestInitialize]
    public void InitializeNodeList() {
        NodeList = new("Alexa");
        NodeList.Append("is");
        NodeList.Append("the");
        NodeList.Append("best!");
    }

    [TestMethod]
    public void Constructor_NullData_ThrowsArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Node<string>(null!));
    }

    [TestMethod]
    public void Append_NullData_ThrowsArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(()=>NodeList.Append(null!));
    }

    [TestMethod]
    public void Exists_NullData_ThrowsArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => NodeList.Exists(null!));
    }

    [TestMethod]
    public void ToString_ValidData_ReturnsStringSuccessfully()
    {
        Assert.AreEqual("Alexa", NodeList.ToString());
        Assert.AreEqual("is", NodeList.Next.ToString());
    }

    [TestMethod]
    public void Append_AddedNodes_SuccessfullyReturnsValue()
    {
        Node<string> newNode = new("Hiiii");
        newNode.Append("You rock");
        newNode.Append("!");

        Assert.AreEqual("You rock", newNode.Next.Data);
        Assert.AreEqual("!", newNode.Next.Next.Data);

    }
    [TestMethod]
    public void Append_DuplicateNodeValue_ThrowsInvalidOperationException()
    {
        Node<string> newNode = new("Copy");
        Assert.ThrowsException<InvalidOperationException>(() => newNode.Append("Copy"));

    }

    [TestMethod]
    public void Clear_ManyNodes_SuccessfullyClears()
    {
        Node<string> newNode = new("Lets goo");
        newNode.Append("New Node1");
        newNode.Append("New Node2");
        newNode.Clear();

        Assert.IsTrue(ReferenceEquals(newNode, newNode.Next));
    }

    [DataTestMethod]
    [DataRow("best!")]
    [DataRow("the")]
    [DataRow("Alexa")]
    public void Exists_NodeExists_ReturnsTrue(string data)
    {
        Assert.IsTrue(NodeList.Exists(data));
    }


    [TestMethod]
    public void Exists_NodeDoesNotExists_ReturnsFalse()
    {
        Assert.IsFalse(NodeList.Exists("Rahat"));
    }

    [TestMethod]
    public void GetEnumerator_ThreeElements_ReturnsSameData()
    {
        Node<string> newNode = new("Boom");
        newNode.Append("Checking");
        newNode.Append("Again");

        Assert.AreEqual(3, newNode.Count());
        Assert.IsTrue(new List<string> { "Boom", "Checking", "Again" }.SequenceEqual(newNode.Select(Node => Node.Data)));
    }

    [TestMethod]
    public void GetEnumeratorMoveNext_FourElements_ReturnsCorrectCount()
    {
        IEnumerator nodeEnumerator = ((IEnumerable)NodeList).GetEnumerator();

        int counter = 0;
        while (nodeEnumerator.MoveNext())
        {
            counter++;
        }
 
        Assert.AreEqual(4, counter);
    }


    [TestMethod]
    public void ChildItems_MaximumFive_ReturnsFiveItems()
    {
        Node<int> numList = new(1);
        numList.Append(2);
        numList.Append(3);
        numList.Append(4);
        numList.Append(5);
        numList.Append(6);

        IEnumerable<Node<int>> nodes = numList.ChildItems(5);

        Assert.IsTrue(new List<int>{2,3,4,5,6}.SequenceEqual(nodes.Select(Node => Node.Data)));
    }

}
