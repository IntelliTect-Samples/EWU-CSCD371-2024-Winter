using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

//Implemented name implicitly, explination in Person class
public record class Student : Person
{
    public Student(FullName name) : base(name) { }
}
