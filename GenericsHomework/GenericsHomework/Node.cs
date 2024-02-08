using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GenericsHomework
{
    public class Node<T>
    {
        // Constructor for Node class
            public Node(T item)
            {
                Value = item ?? throw new NullReferenceException(nameof(item));
                Next = this;
            }
        public Node<T> Next { get; private set; }
        public T Value { get; set; }

    }
}



