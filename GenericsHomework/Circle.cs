using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class Circle<T>
    {
        public string Name { get; }
        public Node<T>? Elements { get; private set; }

        public Circle(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
         }       
        }
    }
