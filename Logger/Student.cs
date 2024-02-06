using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
//Implemented explicitly because middle name can be null and the name can be changed
public record class Student : Person
{
    //public override string Name { get; set; }

    public Student(FullName name) : base(name) { }

/*    public Student(FullName fullName)
    {
        Name = fullName.ToString();
    }*/
}
