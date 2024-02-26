using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment;

public class Node<T> : IEnumerable<T>
{
    public T Data { get; }
    public Node<T> Next { get; private set; }

    public Node(T data)
    {
        Data = data;
        Next = this;
    }

    public override string? ToString()
    {
        if (Data == null) return null;
        return Data.ToString();
    }

    public void Append(T data)
    {
        if(Exists(data))
        {
            throw new ArgumentException("Duplicate Value cannot be added.", nameof(data));
        }
        Node<T> newNode = new(data);
        if(Next == this)
        {
            Next = newNode;
        }
        else
        {
            Node<T> cur = Next;
            while(cur.Next != this)
            {
                cur = cur.Next;
            }
            cur.Next = newNode;
        }
        newNode.Next = this;
    }

    public bool Exists(T data)
    {
        Node<T> cur = this;
        do
        {
            if(EqualityComparer<T>.Default.Equals(cur.Data, data))
            {
                return true;
            }
            cur = cur.Next;
        } while (cur != this);
        return false;
    }

    public void Clear()
    {
        Node<T> cur = this;
        Next = this; 
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> cur = this;
        do
        {
            yield return cur.Data;
            cur = cur.Next;
        } while (cur != this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> ChildItems(int maximum)
    {
        if (maximum < 1) yield break;

        Node<T> cur = this.Next;
        for(int i = 0; i < maximum && cur != this; i++)
        {
            yield return cur.Data;
            cur = cur.Next;
        }
    }
}
