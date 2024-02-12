﻿namespace GenericsHomework;

public class Node<T>
{
    private Node<T>? _Next;
    public T Data { get; set; }
    public Node(T data)
    {
        Data = data;
        Next = this;
    }
    public Node<T> Next { 
        get
        { 
            return _Next!;
        }  
        private set
        { 
            _Next = value;
        } 
    }

    public void Append(T data)
    {
        Node<T> cur = this;

        while( cur.Next != this )
        {
            cur = cur.Next;
        }

        Node<T> nextNode = new(data);
        cur.Next = nextNode;
        nextNode.Next = this;
    }

    public override string ToString()
    {
        Node<T> cur = this;
        string outPut = "Linked List: ";
        int count = 0;

        do{
            count++;
            outPut += $"Node {count}: Data -> {Data} ";
        }while(cur.Next != this);

        outPut += "}";
        return outPut;
    }
}
