using System;
using System.Collections.Generic;
using System.Globalization;
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

        public void AddCircles(Circle<T> circle)
        {
            ArgumentNullException.ThrowIfNull(circle);
            Circles.Add(circle);
        }

        public override string ToString()
        {
            if (Circles == null || Circles.Count == 0)
                return "{}";

            StringBuilder result = new StringBuilder();
            result.Append("{");

            foreach (var circle in Circles)
            {
                result.Append($"{{{circle.Data}}}, ");
            }

            // Remove the trailing comma and space
            result.Length -= 2;

            result.Append("}");

            return result.ToString();
        }

    }
}
