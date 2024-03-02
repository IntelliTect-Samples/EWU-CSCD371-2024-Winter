using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment;

public class Node<T> : IEnumerable<Node<T>> where T : notnull
{
    public Node(T item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item)); 
        Data = item;
        Next = this;
    }

    public Node<T> Next { get; private set; }

    public T Data { get; }
        
    public override string? ToString() 
    {
        return Data.ToString();

    }

    public void Append(T item)
    {
        ArgumentNullException.ThrowIfNull(item,nameof(item));

        if (Exists(item))
        {
                throw new InvalidOperationException(nameof(item));
        }
        else
        {
            Node<T> currentNode = Next;

            while (currentNode.Next != this)
            {
                currentNode = currentNode.Next;
            }
   
            Node<T> newNode = new(item)
            {
                Next = this
            };
                    
            currentNode.Next = newNode;
        }
    }

    public void Clear()
    {
        Next = this;
    }

    public bool Exists(T item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        Node<T> currentNode = this;

    do
    {
        if (currentNode.Data.Equals(item))
        {
            return true;
        }

        currentNode = currentNode.Next;
    } while (currentNode != this);
        return false;
    }

    public IEnumerator<Node<T>> GetEnumerator()
    {
        Node<T> cur = this;
        do{
            yield return cur;
            cur = cur.Next;
        }while (cur != this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    public IEnumerable<Node<T>> ChildItems(int maximum) => this.Skip(1).Take(maximum);
    
}



