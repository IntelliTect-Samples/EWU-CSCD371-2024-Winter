using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Assignment;

public class Node<T> : IEnumerable<Node<T>> where T : notnull
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
        //Prevent null values from being added
        if (value == null) throw new ArgumentNullException(nameof(value));

        //Throw an error on an attempt to Append a duplicate value.
        if (Exists(value)) throw new ArgumentException("Cannot have duplicate: " + nameof(value));

        Node<T> cur = this;

        while (cur.Next != this)
        {
            cur = cur.Next;
        }

        Node<T> newNode = new(value);
        cur.Next = newNode;
        newNode.Next = this;
    }

    public void Clear() 
    {
        Node<T> cur = this;
        cur.Next = this;
    }

    public bool Exists(T value)
    {
        //Search list to see if value exists
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
        Node<T> cur = this;

        do //return all the items in the "circle" of items
        {
            yield return cur;
            cur = cur.Next;

        } while (cur != this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<Node<T>> ChildItems(int maximum)
    {
        //We want the remaining items, so exclude the start node
        Node<T> cur = Next;
        int count = 0;

        while (cur.Next != this && count < maximum)
        {
            yield return cur;
            cur = cur.Next;
            count++;
        }
    }


}
