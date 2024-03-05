using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment;
public class Node<T> : IEnumerable<Node<T>> where T : notnull
{
    private T Value { get; }
    public Node<T> Next { get; private set; }


    public Node(T value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        Value = value;
        Next = this;
    }

    public T GetData()
    {
        return Value;
    }

    override public string ToString()
    {
        return Value?.ToString() ?? throw new ArgumentNullException(nameof(Value));
    }


    public void Clear()
    {
        Next = this;
    }


    public void Append(T data)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));
        Node<T> addition = new(data);

        if (Exists(data))
        {
            throw new ArgumentException($"{data} already exists");
        }

        addition.Next = this.Next;
        Next = addition;
    }



    public bool Exists(T data)
    {
        ArgumentNullException.ThrowIfNull(data, nameof(data));
        Node<T> curr = this;
        if (curr.Value!.Equals(data))
            return true;
        curr = curr.Next;
        while (curr != this)
        {
            if (curr.Value!.Equals(data))
            {
                return true;
            }
            curr = curr.Next;
        }
        return false;
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<Node<T>> GetEnumerator()
    {
        Node<T> cur = this;
        do
        {
            yield return cur;
            cur = cur.Next;
        } while (cur != this);
    }

    public IEnumerable<Node<T>> ChildValues(int max)
    {
        ArgumentNullException.ThrowIfNull(max, nameof(max));
        foreach (var value in this.Skip(1).Take(max))
        {
            yield return value;
        }
    }
}


