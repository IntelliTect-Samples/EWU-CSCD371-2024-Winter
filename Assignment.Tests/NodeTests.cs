﻿using Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Assignment.Tests;

    public class NodeTests
    {
        [Fact]
        public void Node_SingleNode_PointsToSelf()
        {
            Node<string> newNode = new Node<string>("hola");


            Assert.NotNull(newNode.Next); // Ensure Next property is not null
            Assert.Equal(newNode, newNode.Next); // Ensure Next property points to itself
        }
        [Fact]
        public void Append_AddsNodeAfterFirst_Success()
        {
            Node<string> headNode = new("start");
            headNode.Append("second");

            Assert.NotNull(headNode.Next);
            Assert.Equal("second", headNode.Next.Value);
            Assert.Equal("start", headNode.Next.Next.Value); //checks that it is circular and links back to the first node
        }

        [Fact]
        public void Append_AddDuplicateNode_Failure()
        {
            Node<string> headNode = new("start");
            headNode.Append("second");

            Assert.Throws<ArgumentException>(() => headNode.Append("second"));
        }

        [Fact]
        public void Exists_ValueExists_ReturnsTrue()
        {
            Node<string> node = new Node<string>("Hello");

            bool exists = node.Exists("Hello");

            Assert.True(exists);
        }


        [Fact]
        public void Exists_ValueDoesNotExist_ReturnsFalse()
        {
            Node<string> node = new Node<string>("Hello");

            bool exists = node.Exists("World");

            Assert.False(exists);
        }

        [Fact]
        public void ToString_StringMatch_ReturnsCorrectStringRepresentation()
        {
            Node<int> node = new Node<int>(42);

            string result = node.ToString()!;

            Assert.Equal("42", result);
        }

        [Fact]
        public void ToString_HeadsNext_ReturnsCorrectStringRepresentation()
        {
            Node<int> node = new Node<int>(42);
            node.Append(16);

            string result = node.Next.ToString()!;

            Assert.Equal("16", result);
        }

        [Fact]
        public void Clear_OnlyCurrentNodeRemainsinList_Success()
        {
            Node<string> headNode = new("start");
            headNode.Append("second");
            headNode.Append("third");
            headNode.Append("fourth");
            headNode.Clear();
            Assert.Equal("start", headNode.Next.Value);
            Assert.False(headNode.Exists("second"));
            Assert.False(headNode.Exists("third"));
            Assert.False(headNode.Exists("fourth"));
        }

    

    [Fact]
        public void GetEnumerator_Returns_Successful()
        {
            // Arrange: initialize headNode and append 
            Node<int> headNode = new(4);

            headNode.Append(1);
            headNode.Append(2);
            headNode.Append(3);
            int[] expected = [4,3,2,1];

            // Act
            var values = new List<int>();
            foreach (var value in headNode)
            {
                values.Add(value);
            }

            // Assert: verify expected and values match
            Assert.Equal(expected, values);
        }


    [Fact]
        public void GetEnumerator_ReturnsString_Successful()
        {
            // Arrange 
            Node<string> headNode = new("one");

            headNode.Append("two");
            headNode.Next.Append("three");
            headNode.Next.Next.Append("four");
            string[] expected= ["one", "two", "three", "four"];

            // Act
            var values = new List<string>();
            foreach (var value in headNode)
            {
                values.Add(value);
            }

            // Assert
            Assert.Equal(expected, values);
        }

    [Fact]
    public void ChildItems_ReturnsCorrectNumberOfItems_Successful()
    {
        // Arrange
        Node<int> headNode = new(0); 
        headNode.Append(1);
        headNode.Next.Append(2);
        headNode.Next.Next.Append(3);//lazy appending formatting fix
        headNode.Next.Next.Next.Append(4);
        int[] expected = [0, 1, 2]; //append is appendFirst so it comes out weird if everything is appended to the headNode

        // Act
        var actual = headNode.ChildItems(3); 

        // Assert
        Assert.Equal(expected, actual);
    }

}




