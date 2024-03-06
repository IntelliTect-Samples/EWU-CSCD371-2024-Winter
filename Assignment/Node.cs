using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment;

public class Node<T> : IEnumerable<Node<T>> where T : notnull //Circular LinkedList
{
    public T Data { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Data = value;
        Next = this;
    }
     public override string? ToString() => Data.ToString();

    public void Append(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (Exists(value) == true) throw new ArgumentException("Cannot have duplicate: " + nameof(value));

        Node<T> current = this;

        while(current.Next != this)
        {
            current = current.Next;
        }

        Node<T> newNode = new(value);
        current.Next = newNode;
        newNode.Next = this;
    }

    public void Clear() => Next = this;

    public bool Exists(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Node<T> cur = this;

        do
        {
            if (cur.Data.Equals(value)) return true;
            cur = cur.Next;

        } while (cur != this);

        return false;
    }

    public IEnumerator<Node<T>> GetEnumerator()
    {
        Node<T> current = this;
        do
        {
            yield return current;
            current = current.Next;
        } while (current != this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<Node<T>> ChildItems(int maximum)
    {
        int count = 0;
        foreach(var value in this.Skip(1))
        {
            if (count++ == maximum) break;
            yield return value;
        }
    }
}
