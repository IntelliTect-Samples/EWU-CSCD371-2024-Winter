using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
//Implemented implcitily because no data loss at this stage and no collisions
public record class Person : BaseEntity
{
    public override string Name { get; set; }

    public Person(FullName name)
    {
        Name = name.ToString();
    }
}
