using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
//Implemented explicitly because middle name can be null and the name can be changed
public record class Employee : Person
{
    public Employee(FullName name) : base(name) { }

}
