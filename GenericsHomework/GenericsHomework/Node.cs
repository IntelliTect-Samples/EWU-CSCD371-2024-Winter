using System;

namespace GenericsHomework
{
    public class Node<T>
    {
        // Constructor for Node class
            public Node(T item)
            {
                Data = item ?? throw new NullReferenceException(nameof(item));
                Next = this;
            }
        public Node<T> Next { get; private set; }
        public T Data { get; set; }

    }
}



