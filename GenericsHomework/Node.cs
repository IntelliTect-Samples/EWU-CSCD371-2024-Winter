namespace GenericsHomework;

public class Node<T>
{
    public T Data { get; set; }
    public Node(T data)
    {
        Data = data;
        Next = this;
    }
    public Node<T> Next { get; private set;}

    public void Append(T data)
    {

        if(Exists(data))
        {
            throw new ArgumentException("The value already exists");
        }

        Node<T> cur = this;

        Node<T> nextNode = new(data)
        {
            Next = cur.Next
        };
        cur.Next = nextNode;
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

        Node<T> cur = this;

        do
        {
            if (cur.Data!.Equals(data))
            {
                return true;
            }

            cur = cur.Next;

        } while (cur != this);

        return false;
    }

    public void Clear()
    {
        //Yur do not need to worry about Garbage collection if implemented like below.
        //The reason for this is because there does not exist a root reference to the existing object anymore.
        //Thus, the garbage collector will automatically collect the other nodes.
        Node<T> curr = this;

        curr.Next = this;
    }
}
