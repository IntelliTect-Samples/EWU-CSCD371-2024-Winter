namespace GenericsHomework;

public class Node<T>
{
    private Node<T>? _Next;
    public Node(T data)
    {
        Data = data;
        Next = this;
    }

    public T Data { get; set; }
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
        //if size == 1
        Node<T> cur = this;
        

        //if size >1
        while( cur.Next != this )
        {
            cur = cur.Next;
        }


        Node<T> nextNode = new(data);
        cur.Next = nextNode;
        nextNode.Next = cur;

    }
}

