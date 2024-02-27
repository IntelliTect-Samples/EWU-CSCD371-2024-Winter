using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment;

public class Node<T> : IEnumerable<Node<T>> where T : IEquatable<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public bool Exists(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        if(Value == null)
        {
            if(value == null)
            {
                return true;
            }
            return false;
        }
        if(Value.Equals(value))
        {
            return true;
        }
        Node<T> tmp = this;
        do {
            tmp = tmp.Next;
            if(tmp.Value.Equals(value))
            {
                return true;
            }
        } while(tmp != this);
        return false;
    }

    public void Append(T value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if(Exists(value))
        {
            throw new ArgumentException($"the value '{value}' must not exist in the linked list", nameof(value));
        }
        if(Next.Equals(this))
        {
            Next = new(value)
            {
                Next = this
            };
        }
        else
        {
            this.Last().Next = new(value)
            {
                Next = this
            };
        }
    }

    internal bool MoveNext()
    {
        bool atEnd = Next.Equals(this);
        Next = Next.Next;
        return atEnd;
    }

    public IEnumerable<Node<T>> ChildItems(int maximum)
    {
        int n = 0;
        return Next.TakeWhile(child => n++ < maximum);
    }

    public IEnumerator<Node<T>> GetEnumerator() => new NodeEnumerator<T>(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
