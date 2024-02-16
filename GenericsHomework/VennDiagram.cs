using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework
{
    public class VennDiagram<T>
    {
        public List<Circle<T>> Circles { get; private set; }
        public T Data { get; }
        public VennDiagram(IEnumerable<Circle<T>> circles,T data)
        {
            Circles= new List<Circle<T>>(circles);
            Data = data;
        }



    }
}
