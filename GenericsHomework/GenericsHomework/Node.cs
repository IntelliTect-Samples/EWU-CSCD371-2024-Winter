namespace GenericsHomework;

public class Node<T>
{
    private Node<T>? _Next;
    public Node(T data, Node<T> next)
    {
        Data = data;
        Next = next;
    }

    public T Data { get; set; }
    Node<T> Next { 
        get{ return _Next!;}  
        set{ 
            if(value == null){
                _Next = this;
            }
            else{
                _Next = value;
            }
        } 
    }
}

