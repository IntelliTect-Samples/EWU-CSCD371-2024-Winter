using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Person : BaseEntity
{
    //Implemented Name implcitily since FullName is never saved as a property itself so it cant be accessed, so no conflicts
    public override string Name { get; set; }

    public Person(FullName name)
    {
        Name = name.ToString();
    }
}
