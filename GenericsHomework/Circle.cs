using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class Circle<T>
    {

        public Circle(T item)
        {
            Data = item;
            Elements = new Node<T>(item);
        }

        public Node<T> Elements { get; private set; }
        public T Data { get; set; }

        public void Add(T newElement)
        {
            Elements.Append(newElement);
        }
        public override string ToString()
        {
            if (Data == null)
                throw new InvalidOperationException(nameof(Data));
            else
            {
                return Data.ToString()!;
            }
        }

    }
    }
