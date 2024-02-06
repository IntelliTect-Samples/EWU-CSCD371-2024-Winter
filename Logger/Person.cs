using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record class Person : BaseEntity
    {
        public override string Name { get; set; }

        public Person(FullName name)
        {
            Name = name.ToString();
        }
    }
}
