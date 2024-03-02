using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
    public void InitalizeNodeList() {
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
    public void ToString_ValidData_ReturnsStringSuccesfully()
    {
        Assert.AreEqual("Alexa", NodeList.ToString());
        Assert.AreEqual("is", NodeList.Next.ToString());
    }

    [TestMethod]
    public void Append_AddedNodes_SuccesfullyReturnsValue()
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
    public void Node_TwoElements_ReturnsTwoCount()
    {
        Node<string> newNode = new("IEnumerable");
        newNode.Append("Checking");

        Assert.AreEqual(2, newNode.Count());

    }


}