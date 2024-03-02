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
        // We made Data non nullable so precautions have been taken to ensure it can't get set
        // to null
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
        // Data is ensured to be not null so null forgiviness is used.
        if (currentNode.Data!.Equals(item))
        {
            return true;
        }

        currentNode = currentNode.Next;
    } while (currentNode != this);
        return false;
    }

    public IEnumerator<Node<T>> GetEnumerator()
    {
        yield return this;
        for(Node<T> cur = Next; cur != this; cur = cur.Next)
        {
            yield return cur;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return GetEnumerator();
    }

    public IEnumerable<Node<T>> ChildItems(int maximum)
    =>
        this.Skip(1).Take(maximum);
    
}



