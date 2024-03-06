﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment;

/*7.Given the implementation of Node in Assignment5
    Implement IEnumerable<T> to return all the items in the "circle" of items. ❌✔
    Add an IEnumberable<T> ChildItems(int maximum) method to Node that returns the remaining items with a maximum number of items returned less than maximum.*/
public class Node<T> : IEnumerable<T>
{
    public T Value { get; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this; // Points to itself initially
    }
    public void Append(T value)
    {
        // Find the last node in the linked list
        Node<T> lastNode = this;
        while (lastNode.Next != this)
        {
            lastNode = lastNode.Next;
        }

        // Create a new node with the provided value
        Node<T> newNode = new(value);

        // Append the new node to the end of the linked list
        lastNode.Next = newNode;
        newNode.Next = this;
    }


    public void Clear()
    {
        Next = this; // Resetting to point to itself effectively removes all other nodes
    }

    public bool Exists(T value)
    {
        Node<T> current = this;
        do
        {
            if (current.Value!.Equals(value))
            {
                return true;
            }
            current = current.Next;
        } while (current != this); // Loop until we come back to the starting node

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = this;
        while (current != this)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public IEnumerable<T> ChildItems(int max)
    {
        int i = 0;
        Node<T> current = this.Next; // Start from the next node (skip the current one)

        while (current != this && i < max)
        {
            yield return current.Value;
            current = current.Next;
            i++;
        }
    }


}
