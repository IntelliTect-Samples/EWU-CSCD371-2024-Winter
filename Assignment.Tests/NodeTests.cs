﻿using Xunit;

namespace Assignment.Tests;

public class NodeTests
{
    [Fact]
    public void Append_AddsNewNodeToLinkedList()
    {
        // Arrange
        var node = new Node<int>(1);

        // Act
        node.Append(2);

        // Assert
        Assert.Equal(2, node.Next.Value);
    }

    [Fact]
    public void Append_ThrowsExceptionIfValueExists()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => node.Append(2));
    }

    [Fact]
    public void Clear_RemovesAllNodesExceptCurrent()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act
        node.Clear();

        // Assert
        Assert.Same(node, node.Next);
    }

    [Fact]
    public void Exists_ReturnsTrueIfValueExists()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act & Assert
        Assert.True(node.Exists(2));
    }

    [Fact]
    public void Exists_ReturnsFalseIfValueDoesNotExist()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act & Assert
        Assert.False(node.Exists(3));
    }
    [Fact]
    public void Node_ChildItems_successful()
    {
        // Arrange
        Node<int> headNode = new(1);
        headNode.Append(2);
        headNode.Append(8);

        // Act
        IEnumerable<int> test = headNode.ChildItems(2);
        int count = test.Count();
        Assert.NotEmpty(test);
        // Assert
        Assert.Equal(2, count);
    }

}


