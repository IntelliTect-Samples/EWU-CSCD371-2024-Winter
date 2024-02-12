namespace GenericsHomework;

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

        if(Exists(data))
        {
            throw new ArgumentException("The value already exists");
        }

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
            outPut += $"Node {count}: {cur.Data}, ";
            cur = cur.Next;
        }while(cur != this);

        outPut += "}";
        return outPut;
    }

    public bool Exists(T data)
    {
        bool result = false;

        Node<T> cur = this;

        do
        {
            if (cur.Data!.Equals(data))
            {
                result = true;
            }

            cur = cur.Next;

        } while (cur != this);

        return result;
    }

    public void Clear()
    {
        //Yur do not need to wory about Garbage collection if implimented like below.
        //The reason for this is bcause there does not exist a root reference to the existing object anymore.
        //Thus, the garbage collector will atomatically collect the other nodes.
        Node<T> curr = this;

        curr.Next = this;
    }
}
